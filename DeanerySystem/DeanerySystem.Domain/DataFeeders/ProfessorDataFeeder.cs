using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class ProfessorDataFeeder: AbstractDataFeeder<Professor>
    {
        public ProfessorDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override List<Professor> GetData()
        {
            var professors = new List<Professor>
            {
                new Professor
                {
                    //Id = 4,
                    FirstName = "Георгій",
                    LastName = "Шинкаренко",
                    MiddleName = "Андрійович",
                    //UserName = "Shef",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.Professor
                },
                new Professor
                {
                    //Id = 5,
                    FirstName = "Віталій",
                    LastName = "Горлач",
                    MiddleName = "Михайлович",
                    //UserName = "VHM5",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 6,
                    FirstName = "Петро",
                    LastName = "Вагін",
                    MiddleName = "Петрович",
                    //UserName = "PVP6",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 7,
                    FirstName = "Роман",
                    LastName = "Рикалюк",
                    MiddleName = "Євстахович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Марта",
                    LastName = "Жук",
                    MiddleName = "Вікторівна",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Михайло",
                    LastName = "Щербатий",
                    MiddleName = "Васильович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Роман",
                    LastName = "Шандра",
                    MiddleName = "Станіславович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Валерія",
                    LastName = "Семків",
                    MiddleName = "Олегівна",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Віталій",
                    LastName = "Чорненький",
                    MiddleName = "Ігорович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Надія",
                    LastName = "Колос",
                    MiddleName = "Мирославівна",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Святослав",
                    LastName = "Літинський",
                    MiddleName = "Володимирович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Володимир",
                    LastName = "Вовк",
                    MiddleName = "Дмитрович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
                }
            };
            return professors;
        }
    }
}
