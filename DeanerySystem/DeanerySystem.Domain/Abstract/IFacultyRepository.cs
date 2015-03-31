using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Abstract
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> Faculties { get; }
    }
}
