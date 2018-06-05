using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DeanerySystem.BusinessLogic.Utilities.Excel
{
    class ExcelImportData
    {
        public string SheetName { get; set; }
        public ExcelImportStatus Status { get; set; }
        public Columns ColumnConfigurations { get; set; }
        public List<string> Headers { get; set; }
        public List<List<string>> DataRows { get; set; }
        public List<string> Indexes { get; set; }
        public List<List<ExcelCell>> Data
        {
            get
            {
                var data = new List<List<ExcelCell>>();
                this.DataRows.ForEach(dataRow =>
                {
                    var rowData = this.Indexes.Select((t, i) => new ExcelCell()
                    {
                        Index = t,
                        Header = this.Headers[i],
                        Value = dataRow[i]
                    })
                        .ToList();
                    data.Add(rowData);
                });
                return data;
            }
        }

        public ExcelImportData()
        {
            Status = new ExcelImportStatus();
            Headers = new List<string>();
            DataRows = new List<List<string>>();
            Indexes = new List<string>();
        }
    }
}
