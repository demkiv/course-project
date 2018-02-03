using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class ClassDataFeeder: AbstractDataFeeder<Class>
    {
        public ClassDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Class>
            {
                new Class//мсс
                {
                    Id = 1,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(5),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(0)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(0),
                    //    unitOfWork.JournalRepository.Get().ElementAt(1)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(0),
                    //    //entitiesMock.Object.TimeTables.ElementAt(1)
                    //}
                },
                new Class // право
                {
                    Id = 2,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(6),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(1)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(2),
                    //    unitOfWork.JournalRepository.Get().ElementAt(3)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(2)
                    //}
                },
                new Class // право
                {
                    Id = 3,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(7),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(0)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(4),
                    //    unitOfWork.JournalRepository.Get().ElementAt(5)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(3)
                    //}
                },
                new Class
                {
                    Id = 4,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(5),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(0)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(6),
                    //    unitOfWork.JournalRepository.Get().ElementAt(7)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(4)
                    //}
                },
                new Class
                {
                    Id = 5,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(5),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(1)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(8),
                    //    unitOfWork.JournalRepository.Get().ElementAt(9)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(5),
                    //    //entitiesMock.Object.TimeTables.ElementAt(6)
                    //}
                },
                new Class // право
                {
                    Id = 6,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(6),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(1)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(10),
                    //    unitOfWork.JournalRepository.Get().ElementAt(11)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(2)
                    //}
                },
                new Class // право
                {
                    Id = 7,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(8),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(1)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(12),
                    //    unitOfWork.JournalRepository.Get().ElementAt(13)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(3)
                    //}
                },
                new Class // колос
                {
                    Id = 8,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(9),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(4)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(14),
                    //    unitOfWork.JournalRepository.Get().ElementAt(15)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(7),
                    //    //entitiesMock.Object.TimeTables.ElementAt(8)
                    //}
                },
                new Class // вовк
                {
                    Id = 9,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(11),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(5)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(16),
                    //    unitOfWork.JournalRepository.Get().ElementAt(17)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(9),
                    //    //entitiesMock.Object.TimeTables.ElementAt(10)
                    //}
                },
                new Class // літик
                {
                    Id = 10,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get().ElementAt(10),
                                Subject = unitOfWork.SubjectRepository.Get().ElementAt(6)
                    //Journals = new List<Journal>
                    //{
                    //    unitOfWork.JournalRepository.Get().ElementAt(18),
                    //    unitOfWork.JournalRepository.Get().ElementAt(19)
                    //},
                    //TimeTables = new List<TimeTable>
                    //{
                    //    unitOfWork.TimeTableRepository.Get().ElementAt(10)
                    //}
                }
            };
        }
    }
}
