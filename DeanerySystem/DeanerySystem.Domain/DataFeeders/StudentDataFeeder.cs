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
            this.data = new List<Student>
            {
                new Student
                {
                    FirstName = "Соломія",
                    LastName = "Демків",
                    MiddleName = "Тарасівна",
                    LatinFirstName = "Solomiia",
                    LatinLastName = "Demkiv",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Андрій",
                    LastName = "Глова",
                    MiddleName = "Романович",
                    LatinFirstName = "Andriy",
                    LatinLastName = "Hlova",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Соломія",
                    LastName = "Гнідець",
                    MiddleName = "Святославівна",
                    LatinFirstName = "Solomiia",
                    LatinLastName = "Hnidets",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Олег",
                    LastName = "Занік",
                    MiddleName = "Павлович",
                    LatinFirstName = "Oleh",
                    LatinLastName = "Zanik",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Олексій",
                    LastName = "Кондратюк",
                    MiddleName = "Анатолійович",
                    LatinFirstName = "Oleksiy",
                    LatinLastName = "Kndratiuk",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Михайло",
                    LastName = "Копилець",
                    MiddleName = "Миколайович",
                    LatinFirstName = "Mykhailo",
                    LatinLastName = "Kopylets",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Христина",
                    LastName = "Михайлюк",
                    MiddleName = "Володимирівна",
                    LatinFirstName = "Khrystyna",
                    LatinLastName = "Mykhailyuk",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Олеся",
                    LastName = "Мідяна",
                    MiddleName = "Іванівна",
                    LatinFirstName = "Olesya",
                    LatinLastName = "Midyana",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Микола",
                    LastName = "Молочій",
                    MiddleName = "Вікторович",
                    LatinFirstName = "Mykola",
                    LatinLastName = "Molochiy",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Ігор",
                    LastName = "Романчук",
                    MiddleName = "Володимирович",
                    LatinFirstName = "Ihor",
                    LatinLastName = "Romanchuk",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Тарас",
                    LastName = "Романчук",
                    MiddleName = "Григорович",
                    LatinFirstName = "Taras",
                    LatinLastName = "Romanchuk",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Богдан",
                    LastName = "Смачило",
                    MiddleName = "Васильович",
                    LatinFirstName = "Bohdan",
                    LatinLastName = "Smachylo",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Маркіян",
                    LastName = "Фостяк",
                    MiddleName = "Романович",
                    LatinFirstName = "Markiyan",
                    LatinLastName = "Fostyak",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Софія",
                    LastName = "Хомин",
                    MiddleName = "Андріївна",
                    LatinFirstName = "Sofiya",
                    LatinLastName = "Khomyn",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Данило",
                    LastName = "Юристовський",
                    MiddleName = "Орестович",
                    LatinFirstName = "Danylo",
                    LatinLastName = "Yurystovskiy",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                },
                new Student
                {
                    FirstName = "Вікторія",
                    LastName = "Юріяк",
                    MiddleName = "Віталіївна",
                    LatinFirstName = "Viktoria",
                    LatinLastName = "Yuriyak",
                    TuitionFee = TuitionFees.Scholar,
                    Group = this.unitOfWork.GroupRepository.GetById(1)
                }
            };
        }
    }
}
