using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeanerySystem.UI.Models.Admin
{
    public class GeneralInfo
    {
        public int FacultiesCount { get; set; }
        public int StreamsCount { get; set; }
        public int DepartmentsCount { get; set; }
        public int GroupsCount { get; set; }
        public int ProfessorsCount { get; set; }
        public int StudentsCount { get; set; }
        public University University { get; set; }
    }
}