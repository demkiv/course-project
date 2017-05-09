using System.Collections.Generic;

namespace DeanerySystem.UI.Models
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