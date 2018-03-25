using System;

namespace DeanerySystem.BusinessLogic.Utilities.Excel
{
    /// <summary>
    /// Maps property to Excel cell using column index 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class MapExcelAttribute : Attribute
    {
        public MapExcelAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
        public string ColumnName { get; set; }
    }
}
