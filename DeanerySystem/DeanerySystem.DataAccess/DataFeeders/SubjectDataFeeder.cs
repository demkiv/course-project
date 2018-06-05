using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class SubjectDataFeeder:AbstractDataFeeder<Subject>
    {
        public SubjectDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Subject>
            {
                new Subject
                {
                    Id = 1,
                    Name = "Моделювання складних систем",
                    SemesterControl = SemesterControlTypes.Credit,
                    NumberOfConsultations = 0,
                    NumberOfLectures = 0,
                    NumberOfPracticalClasses = 17,
                    NumberOflLaboratoryClasses = 0,
                    PassingDate = new DateTime(2015, 6, 6)
                },
                new Subject
                {
                    Id = 2,
                    Name = "Основи права та основи конституційного права",
                    SemesterControl = SemesterControlTypes.Credit,
                    PassingDate = new DateTime(2015, 6, 6)
                },
                new Subject
                {
                    Id = 3,
                    Name = "Моделювання складних систем",
                    SemesterControl = SemesterControlTypes.Credit,
                    PassingDate = new DateTime(2015, 6, 6)
                },
                new Subject
                {
                    Id = 4,
                    Name = "Основи права та основи конституційного права",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6)
                },
                new Subject
                {
                    Id = 5,
                    Name = "Системи штучного інтелекту",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6)
                },
                new Subject
                {
                    Id = 6,
                    Name = "Чисельні методи математичної фізики",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6)
                },
                new Subject
                {
                    Id = 7,
                    Name = "Програмування під UNIX-подібними системами",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6)
                }
            };
        }
    }
}
