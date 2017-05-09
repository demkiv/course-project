using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class FacultyDataFeeder: AbstractDataFeeder<Faculty>
    {
        public FacultyDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public override List<Faculty> GetData()
        {
            var facultioes = new List<Faculty>
            {
                new Faculty {Id = 1, Name = "Biology"},
                new Faculty {Id = 2, Name = "Geography"},
                new Faculty {Id = 3, Name = "Geology"},
                new Faculty {Id = 4, Name = "Economics"},
                new Faculty {Id = 5, Name = "Electronics"},
                new Faculty {Id = 6, Name = "Jornalism"},
                new Faculty {Id = 7, Name = "Foreign Languages"},
                new Faculty {Id = 8, Name = "History"},
                new Faculty {Id = 9, Name = "Culture and Arts"},
                new Faculty {Id = 10, Name = "International Relations"},
                new Faculty {Id = 11, Name = "Mechanics and Mathematics"},
                new Faculty {Id = 12, Name = "Applied Mathematics and Information Science"},
                new Faculty {Id = 13, Name = "Physics"},
                new Faculty {Id = 14, Name = "Philology"},
                new Faculty {Id = 15, Name = "Philosophy"},
                new Faculty {Id = 16, Name = "Chemistry"},
                new Faculty {Id = 17, Name = "Law"}
            };
            return facultioes;
        }
    }
}
