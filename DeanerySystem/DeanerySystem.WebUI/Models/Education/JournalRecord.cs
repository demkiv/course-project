﻿using System.Collections.Generic;

namespace DeanerySystem.WebUI.Models
{
    public class JournalRecord
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentMiddleName { get; set; }

        public List<string> Marks { get; set; }
    }
}
