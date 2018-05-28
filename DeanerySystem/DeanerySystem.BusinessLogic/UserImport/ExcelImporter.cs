using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DeanerySystem.BusinessLogic.UserImport.Models;
using DeanerySystem.BusinessLogic.Utilities.Excel;

namespace DeanerySystem.BusinessLogic.UserImport
{
    /// <summary>
    /// Imports users form excel file
    /// </summary>
    class ExcelImporter : IImporter
    {
        public List<UserModel> ImportData(Stream stream)
        {
            var users = new List<UserModel>();
            var excelUtility = new ExcelUtility();
            var importedData = excelUtility.ReadExcel(stream);
            importedData.Data.ForEach(dataRow =>
            {
                var user = this.ParseDataRow(dataRow);
                users.Add(user);
            });
            return users;
        }

        private UserModel ParseDataRow(List<ExcelCell> dataRow)
        {
            var user = new UserModel();
            dataRow.ForEach(cell => { this.SetPropertyValue(user, cell); });
            return user;
        }

        private void SetPropertyValue(UserModel user, ExcelCell cell)
        {
            var propertyInfo = user.GetType().GetProperties().Single(p => p
                .GetCustomAttributes(true)
                .Any(
                    attr => attr is MapExcelAttribute excelMap && excelMap.ColumnName == cell.Index));
            if (propertyInfo.PropertyType == typeof(DateTime?))
            {
                this.SetDateTime(user, cell, propertyInfo);
            }
            else
            {
                var typedValue = Convert.ChangeType(cell.Value, propertyInfo.PropertyType);
                propertyInfo.SetValue(user, typedValue, null);
            }
        }

        //TODO: if more types handling needed - implement converters and factory 
        private void SetDateTime(UserModel user, ExcelCell cell, PropertyInfo propertyInfo)
        {
            var isParsed = double.TryParse(cell.Value, out var dateDays);
            if (isParsed)
            {
                var date = DateTime.FromOADate(dateDays);
                propertyInfo.SetValue(user, date, null);
            }
        }
    }
}
