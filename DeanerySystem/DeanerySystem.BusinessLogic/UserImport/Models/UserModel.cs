using System;
using DeanerySystem.BusinessLogic.Utilities.Excel;

namespace DeanerySystem.BusinessLogic.UserImport.Models
{
    public class UserModel
    {
        [MapExcel("A")]
        public string StudentCardNumber { get; set; }
        [MapExcel("B")]
        public string FirstName { get; set; }
        [MapExcel("C")]
        public string MiddleName { get; set; }
        [MapExcel("D")]
        public string LastName { get; set; }
        [MapExcel("E")]
        public string LatinFirstName { get; set; }
        [MapExcel("F")]
        public string LatinLastName { get; set; }
        [MapExcel("G")]
        public string Email { get; set; }
        [MapExcel("H")]
        public string PhoneNumber { get; set; }
        [MapExcel("I")]
        public DateTime? BirthDate { get; set; }
        [MapExcel("J")]
        public int Stream { get; set; }
        [MapExcel("K")]
        public int Group { get; set; }
    }
}
