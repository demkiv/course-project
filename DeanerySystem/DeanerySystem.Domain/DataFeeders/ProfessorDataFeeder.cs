using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class ProfessorDataFeeder : AbstractDataFeeder<Professor>
    {
        public ProfessorDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Professor>
            {
                new Professor
                {
                    //Id = 4,
                    FirstName = "Георгій",
                    LastName = "Шинкаренко",
                    MiddleName = "Андрійович",
                    LatinFirstName = "Heorhii",
                    LatinLastName = "Shynkarenko",
                    HeadOfDepartment = unitOfWork.DepartmentRepository.GetById(2),
                    //UserName = "Shef",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.Professor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    //Id = 5,
                    FirstName = "Віталій",
                    LastName = "Горлач",
                    MiddleName = "Михайлович",
                    LatinFirstName = "Vitalii",
                    LatinLastName = "Horlatch",
                    //UserName = "VHM5",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    //Id = 6,
                    FirstName = "Петро",
                    LastName = "Вагін",
                    MiddleName = "Петрович",
                    LatinFirstName = "Petro",
                    LatinLastName = "Vahin",
                    //UserName = "PVP6",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    //Id = 7,
                    FirstName = "Роман",
                    LastName = "Рикалюк",
                    MiddleName = "Євстахович",
                    LatinFirstName = "Roman",
                    LatinLastName = "Rykalyuk",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Марта",
                    LastName = "Жук",
                    MiddleName = "Вікторівна",
                    LatinFirstName = "Marta",
                    LatinLastName = "Zhuk",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Михайло",
                    LastName = "Щербатий",
                    MiddleName = "Васильович",
                    LatinFirstName = "Mykhailo",
                    LatinLastName = "Scherbatyy",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Роман",
                    LastName = "Шандра",
                    MiddleName = "Станіславович",
                    LatinFirstName = "Roman",
                    LatinLastName = "Shandra",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Валерія",
                    LastName = "Семків",
                    MiddleName = "Олегівна",
                    LatinFirstName = "Valeriya",
                    LatinLastName = "Semkiv",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Віталій",
                    LastName = "Чорненький",
                    MiddleName = "Ігорович",
                    LatinFirstName = "Vitalii",
                    LatinLastName = "Chornenkiy",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Надія",
                    LastName = "Колос",
                    MiddleName = "Мирославівна",
                    LatinFirstName = "Nadiya",
                    LatinLastName = "Kolos",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Святослав",
                    LastName = "Літинський",
                    MiddleName = "Володимирович",
                    LatinFirstName = "Svyatoslav",
                    LatinLastName = "Litynskiy",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Володимир",
                    LastName = "Вовк",
                    MiddleName = "Дмитрович",
                    LatinFirstName = "Volodymyr",
                    LatinLastName = "Vovk",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Сергій",
                    LastName = "Ярошко",
                    MiddleName = "Адамович",
                    LatinFirstName = "Serhiy",
                    LatinLastName = "Yaroshko",
                    //Role = Roles.Professor,
                    HeadOfDepartment = unitOfWork.DepartmentRepository.GetById(2),
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Тарас",
                    LastName = "Заболоцький",
                    MiddleName = "Миколайович",
                    LatinFirstName = "Taras",
                    LatinLastName = "Zabolotskiy",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Андрій",
                    LastName = "Кардаш",
                    MiddleName = "Іванович",
                    LatinFirstName = "Andriy",
                    LatinLastName = "Kardash",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Леся",
                    LastName = "Клакович",
                    MiddleName = "Миронівна",
                    LatinFirstName = "Lesya",
                    LatinLastName = "Klakovych",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Анатолій",
                    LastName = "Музичук",
                    MiddleName = "Омелянович",
                    LatinFirstName = "Anatoliy",
                    LatinLastName = "Muzychuk",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Богдан",
                    LastName = "Подлевський",
                    MiddleName = "Михайлович",
                    LatinFirstName = "Bohdan",
                    LatinLastName = "Podlevskyy",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    //Id = 8,
                    FirstName = "Юрій",
                    LastName = "Сибіль",
                    MiddleName = "Миколайович",
                    LatinFirstName = "Yuriy",
                    LatinLastName = "Sybil",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
            };
        }
    }
}
