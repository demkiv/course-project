using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class StudentDataFeeder: AbstractDataFeeder<Student>
    {
        public StudentDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override List<Student> GetData()
        {
            var students = new List<Student>
            {
                new Student
                {
                    //Id = 1,
                    FirstName = "Богдан",
                    LastName = "Андрусяк",
                    MiddleName = "Тарасович",
                    //UserName = "ABT1",
                    //Password = "1",
                    //Role = Roles.Student,
                    StudentCode = "BC123456",
                    TuitionFee = TuitionFees.Scholar
                },
                new Student
                {
                    //Id = 2,
                    FirstName = "Володимир",
                    LastName = "Будзан",
                    MiddleName = "Іванович",
                    //UserName = "VBV2",
                    //Password = "1",
                    //Role = Roles.Student,
                    StudentCode = "BC123457",
                    TuitionFee = TuitionFees.Scholar
                },
                new Student
                {
                    //Id = 3,
                    FirstName = "Микола",
                    LastName = "Ванькович",
                    MiddleName = "Дмитрович",
                    //UserName = "MVM3",
                    //Password = "1",
                    //Role = Roles.Student,
                    StudentCode = "BC123458",
                    TuitionFee = TuitionFees.Scholar
                },
                new Student
                {
                    //Id = 4,
                    FirstName = "Соломія",
                    LastName = "Демків",
                    MiddleName = "Тарасівна"
                },
                new Student
                {
                    //Id = 5,
                    FirstName = "Марія-Ярина",
                    LastName = "Джала",
                    MiddleName = "Юріївна"
                },
                new Student
                {
                    //Id = 6,
                    FirstName = "Андрій",
                    LastName = "Дячук",
                    MiddleName = "Валерійович"
                },
                new Student
                {
                    //Id = 7,
                    FirstName = "Назарій",
                    LastName = "Корчак",
                    MiddleName = "Юрійович"
                },
                new Student
                {
                    //Id = 8,
                    FirstName = "Орест",
                    LastName = "Купин",
                    MiddleName = "Андрійович"
                },
                new Student
                {
                    //Id = 9,
                    FirstName = "Анастасія",
                    LastName = "Ладанівська",
                    MiddleName = "Борисівна"
                },
                new Student
                {
                    //Id = 10,
                    FirstName = "Денис",
                    LastName = "Лебедович",
                    MiddleName = "Олегович"
                },
                new Student
                {
                    //Id = 11,
                    FirstName = "Ігор",
                    LastName = "Михаляк",
                    MiddleName = "Ярославович"
                },
                new Student
                {
                    //Id = 12,
                    FirstName = "Юрій",
                    LastName = "Олексишин",
                    MiddleName = "Юрійович"
                },
                new Student
                {
                    //Id = 13,
                    FirstName = "Володимир",
                    LastName = "Пабирівський",
                    MiddleName = "Вікторович"
                },
                new Student
                {
                    //Id = 14,
                    FirstName = "Маркіян",
                    LastName = "Різун",
                    MiddleName = "Тарасович"
                },
                new Student
                {
                    //Id = 15,
                    FirstName = "Михайло",
                    LastName = "Рімель",
                    MiddleName = "Йосифович"
                },
                new Student
                {
                    //Id = 16,
                    FirstName = "Роман",
                    LastName = "Слєпко",
                    MiddleName = "Ігорович"
                },
                new Student
                {
                    //Id = 17,
                    FirstName = "Василь",
                    LastName = "Хміль",
                    MiddleName = "Ігорович"
                },
                new Student
                {
                    //Id = 18,
                    FirstName = "Володимир",
                    LastName = "Хміль",
                    MiddleName = "Ярославович"
                },
                new Student
                {
                    //Id = 19,
                    FirstName = "Мар’яна",
                    LastName = "Ходачник",
                    MiddleName = "Ростиславівна"
                },
                new Student
                {
                    //Id = 20,
                    FirstName = "Анна-Марія",
                    LastName = "Юрочко",
                    MiddleName = "Вікторівна"
                },
                new Student
                {
                    FirstName = "Маркіян",
                    LastName = "Воробель",
                    MiddleName = "Романович"
                },
                new Student
                {
                    FirstName = "Назар",
                    LastName = "Герман",
                    MiddleName = "Романович"
                },
                new Student
                {
                    FirstName = "Андрій",
                    LastName = "Глова",
                    MiddleName = "Романович"
                },
                new Student
                {
                    FirstName = "Соломія",
                    LastName = "Гнідець",
                    MiddleName = "Святославівна"
                },
                new Student
                {
                    FirstName = "Андрій",
                    LastName = "Євчак",
                    MiddleName = "Михайлович"
                },
                new Student
                {
                    FirstName = "Олег",
                    LastName = "Занік",
                    MiddleName = "Павлович"
                },
                new Student
                {
                    FirstName = "Олексій",
                    LastName = "Кондратюк",
                    MiddleName = "Анатолійович"
                },
                new Student
                {
                    FirstName = "Михайло",
                    LastName = "Копилець",
                    MiddleName = "Миколайович"
                },
                new Student
                {
                    FirstName = "Христина",
                    LastName = "Михайлюк",
                    MiddleName = "Володимирівна"
                },
                new Student
                {
                    FirstName = "Олеся",
                    LastName = "Мідяна",
                    MiddleName = "Іванівна"
                },
                new Student
                {
                    FirstName = "Микола",
                    LastName = "Молочій",
                    MiddleName = "Вікторівна"
                },
                new Student
                {
                    FirstName = "Юрій",
                    LastName = "Плоский",
                    MiddleName = "Васильович"
                },
                new Student
                {
                    FirstName = "Ігор",
                    LastName = "Романчук",
                    MiddleName = "Володимирович"
                },
                new Student
                {
                    FirstName = "Тарас",
                    LastName = "Романчук",
                    MiddleName = "Григорович"
                },
                new Student
                {
                    FirstName = "Богдан",
                    LastName = "Смачило",
                    MiddleName = "Васильович"
                },
                new Student
                {
                    FirstName = "Маркіян",
                    LastName = "Фостяк",
                    MiddleName = "Романович"
                },
                new Student
                {
                    FirstName = "Софія",
                    LastName = "Хомин",
                    MiddleName = "Андріївна"
                },
                new Student
                {
                    FirstName = "Володимир",
                    LastName = "Чіх",
                    MiddleName = "Іванович"
                },
                new Student
                {
                    FirstName = "Данило",
                    LastName = "Юристовський",
                    MiddleName = "Орестович"
                },
                new Student
                {
                    FirstName = "Вікторія",
                    LastName = "Юріяк",
                    MiddleName = "Віталіївна"
                }
            };
            return students;
        }
    }
}
