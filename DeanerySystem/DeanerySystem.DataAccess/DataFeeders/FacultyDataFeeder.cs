using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class FacultyDataFeeder: AbstractDataFeeder<Faculty>
    {
        public FacultyDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var university = unitOfWork.UniversityRepository.GetById(1); 
            this.data = new List<Faculty>
            {
                new Faculty {Id = 1, Name = "Біологічний факультет", University = university},
                new Faculty {Id = 2, Name = "Географічний факультет", University = university},
                new Faculty {Id = 3, Name = "Геологічний факультет", University = university},
                new Faculty {Id = 4, Name = "Економічний факультет", University = university},
                new Faculty {Id = 5, Name = "Факультет електроніки та комп'ютерних технологій", University = university},
                new Faculty {Id = 6, Name = "Факультет журналістики", University = university},
                new Faculty {Id = 7, Name = "Факультет іноземних мов", University = university},
                new Faculty {Id = 8, Name = "Історичний факультет", University = university},
                new Faculty {Id = 9, Name = "Факультет культури та мистецтв", University = university},
                new Faculty {Id = 10, Name = "Механіко-математичний факультет", University = university},
                new Faculty {Id = 11, Name = "Факультет міжнародних відносин", University = university},
                new Faculty {Id = 12, Name = "Факультет педагогічної освіти", University = university},
                new Faculty {Id = 13, Name = "Факультет прикладної математики та інформатики", University = university},
                new Faculty {Id = 14, Name = "Факультет управління фінансами та бізнесу", University = university},
                new Faculty {Id = 15, Name = "Фізичний факультет", University = university},
                new Faculty {Id = 16, Name = "Філологічний факультет", University = university},
                new Faculty {Id = 17, Name = "Філософський факультет", University = university},
                new Faculty {Id = 18, Name = "Хімічний факультет", University = university},
                new Faculty {Id = 19, Name = "Юридичний факультет", University = university}
            };

            this.Data.ForEach(f => university.Faculties.Add(f));
        }
    }
}
