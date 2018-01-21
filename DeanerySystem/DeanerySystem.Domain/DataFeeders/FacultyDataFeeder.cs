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
           
            this.data = new List<Faculty>
            {
                new Faculty {Id = 1, Name = "Біологічний факультет"},
                new Faculty {Id = 2, Name = "Географічний факультет"},
                new Faculty {Id = 3, Name = "Геологічний факультет"},
                new Faculty {Id = 4, Name = "Економічний факультет"},
                new Faculty {Id = 5, Name = "Факультет електроніки та комп'ютерних технологій"},
                new Faculty {Id = 6, Name = "Факультет журналістики"},
                new Faculty {Id = 7, Name = "Факультет іноземних мов"},
                new Faculty {Id = 8, Name = "Історичний факультет"},
                new Faculty {Id = 9, Name = "Факультет культури та мистецтв"},
                new Faculty {Id = 10, Name = "Механіко-математичний факультет"},
                new Faculty {Id = 11, Name = "Факультет міжнародних відносин"},
                new Faculty {Id = 12, Name = "Факультет педагогічної освіти"},
                new Faculty {Id = 13, Name = "Факультет прикладної математики та інформатики"},
                new Faculty {Id = 14, Name = "Факультет управління фінансами та бізнесу"},
                new Faculty {Id = 15, Name = "Фізичний факультет"},
                new Faculty {Id = 16, Name = "Філологічний факультет"},
                new Faculty {Id = 17, Name = "Філософський факультет"},
                new Faculty {Id = 18, Name = "Хімічний факультет"},
                new Faculty {Id = 19, Name = "Юридичний факультет"}
            };
        }
    }
}
