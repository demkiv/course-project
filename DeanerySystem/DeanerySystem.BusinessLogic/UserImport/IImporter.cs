using DeanerySystem.BusinessLogic.UserImport.Models;
using System.Collections.Generic;
using System.IO;

namespace DeanerySystem.BusinessLogic.UserImport
{
    interface IImporter
    {
        List<UserModel> ImportData(Stream stream); 
    }
}
