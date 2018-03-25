using DeanerySystem.BusinessLogic.UserImport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeanerySystem.BusinessLogic.UserImport
{
    interface IImporter
    {
        List<UserModel> ImportData(Stream stream); 
    }
}
