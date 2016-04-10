using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeanerySystem.UI.Models.Admin
{
    public class University
    {
        public string Name { get; set; }
        public string RectorFirstName { get; set; }
        public string RectorLastName { get; set; }
        public Guid RectorId { get; set; }
    }
}