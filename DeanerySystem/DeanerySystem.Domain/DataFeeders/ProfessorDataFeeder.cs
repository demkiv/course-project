using System;
using System.Collections.Generic;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Entities.Identity;
using DeanerySystem.Domain.Identity;
using Microsoft.AspNet.Identity;

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
                    FirstName = "Сергій",
                    LastName = "Ярошко",
                    MiddleName = "Адамович",
                    LatinFirstName = "Serhiy",
                    LatinLastName = "Yaroshko",
                    HeadOfDepartment = unitOfWork.DepartmentRepository.GetById(1),
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Георгій",
                    LastName = "Шинкаренко",
                    MiddleName = "Андрійович",
                    LatinFirstName = "Heorhii",
                    LatinLastName = "Shynkarenko",
                    HeadOfDepartment = unitOfWork.DepartmentRepository.GetById(2),
                    Position = Positions.Professor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    FirstName = "Віталій",
                    LastName = "Горлач",
                    MiddleName = "Михайлович",
                    LatinFirstName = "Vitalii",
                    LatinLastName = "Horlatch",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    FirstName = "Петро",
                    LastName = "Вагін",
                    MiddleName = "Петрович",
                    LatinFirstName = "Petro",
                    LatinLastName = "Vahin",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    FirstName = "Роман",
                    LastName = "Рикалюк",
                    MiddleName = "Євстахович",
                    LatinFirstName = "Roman",
                    LatinLastName = "Rykalyuk",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Марта",
                    LastName = "Жук",
                    MiddleName = "Вікторівна",
                    LatinFirstName = "Marta",
                    LatinLastName = "Zhuk",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    FirstName = "Михайло",
                    LastName = "Щербатий",
                    MiddleName = "Васильович",
                    LatinFirstName = "Mykhailo",
                    LatinLastName = "Scherbatyy",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    FirstName = "Роман",
                    LastName = "Шандра",
                    MiddleName = "Станіславович",
                    LatinFirstName = "Roman",
                    LatinLastName = "Shandra",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    FirstName = "Валерія",
                    LastName = "Семків",
                    MiddleName = "Олегівна",
                    LatinFirstName = "Valeriya",
                    LatinLastName = "Semkiv",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    FirstName = "Віталій",
                    LastName = "Чорненький",
                    MiddleName = "Ігорович",
                    LatinFirstName = "Vitalii",
                    LatinLastName = "Chornenkiy",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    FirstName = "Надія",
                    LastName = "Колос",
                    MiddleName = "Мирославівна",
                    LatinFirstName = "Nadiya",
                    LatinLastName = "Kolos",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(3)
                },
                new Professor
                {
                    FirstName = "Святослав",
                    LastName = "Літинський",
                    MiddleName = "Володимирович",
                    LatinFirstName = "Svyatoslav",
                    LatinLastName = "Litynskiy",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Володимир",
                    LastName = "Вовк",
                    MiddleName = "Дмитрович",
                    LatinFirstName = "Volodymyr",
                    LatinLastName = "Vovk",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(2)
                },
                new Professor
                {
                    FirstName = "Тарас",
                    LastName = "Заболоцький",
                    MiddleName = "Миколайович",
                    LatinFirstName = "Taras",
                    LatinLastName = "Zabolotskiy",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Андрій",
                    LastName = "Кардаш",
                    MiddleName = "Іванович",
                    LatinFirstName = "Andriy",
                    LatinLastName = "Kardash",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Леся",
                    LastName = "Клакович",
                    MiddleName = "Миронівна",
                    LatinFirstName = "Lesya",
                    LatinLastName = "Klakovych",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1),
                    RectorOfUniversity = unitOfWork.UniversityRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Анатолій",
                    LastName = "Музичук",
                    MiddleName = "Омелянович",
                    LatinFirstName = "Anatoliy",
                    LatinLastName = "Muzychuk",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Богдан",
                    LastName = "Подлевський",
                    MiddleName = "Михайлович",
                    LatinFirstName = "Bohdan",
                    LatinLastName = "Podlevskyy",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Юрій",
                    LastName = "Сибіль",
                    MiddleName = "Миколайович",
                    LatinFirstName = "Yuriy",
                    LatinLastName = "Sybil",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1)
                },
                new Professor
                {
                    FirstName = "Іван",
                    LastName = "Дияк",
                    MiddleName = "Іванович",
                    LatinFirstName = "Ivan",
                    LatinLastName = "Dyyak",
                    Position = Positions.AssociateProfessor,
                    Department = unitOfWork.DepartmentRepository.GetById(1),
                    DeanOfFaculty = unitOfWork.FacultyRepository.GetById(13)
                }
            };

            this.Data.ForEach(prof =>
            {
                prof.UserName =
                    $"{prof.LatinFirstName.ToLower()}.{prof.LatinLastName.ToLower()}@edeanery.com";
                prof.Email = $"{prof.LatinFirstName.ToLower()}.{prof.LatinLastName.ToLower()}@edeanery.com";
                prof.EmailConfirmed = true;
                prof.Department.Professors.Add(prof);
                if (this.unitOfWork.Context != null)
                {
                    var manager = new IdentityUtilityManager(this.unitOfWork);
                    manager.CreateAccount(prof, Roles.Professor);
                }
                if (prof.RectorOfUniversity != null)
                    prof.RectorOfUniversity.Rector = prof;

                if (prof.DeanOfFaculty != null)
                    prof.DeanOfFaculty.Dean = prof;

                if (prof.HeadOfDepartment != null)
                    prof.HeadOfDepartment.Head = prof;
            });
        }
    }
}
