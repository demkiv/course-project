using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeanerySystem.WebUI.Models
{
    public class JournalRecord
    {
        public int Number { get; set; }

        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentMiddleName { get; set; }

        public List<string> Marks { get; set; }
    }
}