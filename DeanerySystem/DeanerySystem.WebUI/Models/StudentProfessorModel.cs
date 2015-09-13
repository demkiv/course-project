using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.WebUI.Models
{
    public class StudentProfessorModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Professor> Professors { get; set; }
    }
}