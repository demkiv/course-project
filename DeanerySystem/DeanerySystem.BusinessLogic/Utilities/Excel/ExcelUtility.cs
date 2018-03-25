using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DeanerySystem.BusinessLogic.Utilities.Excel
{
    /// <summary>
    /// Reads data from excel sheet
    /// </summary>
    //https://www.codeproject.com/Articles/670141/Read-and-Write-Microsoft-Excel-with-Open-XML-SDK
    class ExcelUtility
    {
        public ExcelImportData ReadExcel(Stream stream)
        {
            var data = new ExcelImportData();
            WorkbookPart workbookPart;
 
            List<Row> rows;
            try
            {
                ReadDocumentMetadata(stream, out workbookPart, out rows, data);
            }
            catch (Exception e)
            {
                data.Status.Message = "Unable to open the file";
                return data;
            }

            this.ReadHeader(workbookPart, rows, data);
            this.GetData(workbookPart, rows, data);

            return data;
        }

        private string GetColumnName(string cellReference)
        {
            var regex = new Regex("[A-Za-z]+");
            var match = regex.Match(cellReference);
            return match.Value;
        }

        private int ConvertColumnNameToNumber(string columnName)
        {
            var alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            var convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64;
                convertedValue += current * (int)Math.Pow(26, i);
            }
            return convertedValue;
        }

        private IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);
                int currentColumnIndex = ConvertColumnNameToNumber(columnName);
                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    var emptycell = new Cell()
                    {
                        DataType = null,
                        CellValue = new CellValue(string.Empty)
                    };
                    yield return emptycell;
                }
                yield return cell;
                currentCount++;
            }
        }

        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable
                    .Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }

            return (text ?? string.Empty).Trim();
        }

        private void ReadDocumentMetadata(Stream stream, out WorkbookPart workbookPart, out List<Row> rows,  ExcelImportData data)
        {
            var document = SpreadsheetDocument.Open(stream, false);
            workbookPart = document.WorkbookPart;

            var sheets = workbookPart.Workbook.Descendants<Sheet>();
            var sheet = sheets.First();
            data.SheetName = sheet.Name;

            var workSheet = ((WorksheetPart)workbookPart
                .GetPartById(sheet.Id)).Worksheet;
            var columns = workSheet.Descendants<Columns>().FirstOrDefault();
            data.ColumnConfigurations = columns;

            var sheetData = workSheet.Elements<SheetData>().First();
            rows = sheetData.Elements<Row>().ToList();
        }

        private void ReadHeader(WorkbookPart workbookPart, IReadOnlyList<Row> rows, ExcelImportData data)
        {
            if (rows.Count > 0)
            {
                var row = rows[0];
                var cellEnumerator = GetExcelCellEnumerator(row);
                while (cellEnumerator.MoveNext())
                {
                    var cell = cellEnumerator.Current;
                    var text = ReadExcelCell(cell, workbookPart).Trim();
                    data.Headers.Add(text);
                    data.Indexes.Add(GetColumnName(cell.CellReference));
                }
            }
        }

        private void GetData(WorkbookPart workbookPart, IReadOnlyList<Row> rows, ExcelImportData data)
        {
            if (rows.Count > 1)
            {
                for (var i = 1; i < rows.Count; i++)
                {
                    var dataRow = new List<string>();
                    data.DataRows.Add(dataRow);
                    var row = rows[i];
                    var cellEnumerator = GetExcelCellEnumerator(row);
                    while (cellEnumerator.MoveNext())
                    {
                        var cell = cellEnumerator.Current;
                        var text = ReadExcelCell(cell, workbookPart).Trim();
                        dataRow.Add(text);
                    }
                }
            }
        }
    }
}
