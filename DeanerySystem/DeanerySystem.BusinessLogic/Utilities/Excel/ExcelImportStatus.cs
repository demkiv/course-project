namespace DeanerySystem.BusinessLogic.Utilities.Excel
{
    class ExcelImportStatus
    {
        public string Message { get; set; }
        public bool Success => string.IsNullOrWhiteSpace(Message);
    }
}
