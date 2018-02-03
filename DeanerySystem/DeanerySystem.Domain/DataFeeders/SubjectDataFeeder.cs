using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class SubjectDataFeeder: AbstractDataFeeder<Subject>
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
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(0)
                    //}
                },
                new Subject
                {
                    Id = 2,
                    Name = "Основи права та основи конституційного права",
                    SemesterControl = SemesterControlTypes.Credit,
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(1),
                    //    unitOfWork.ClassRepository.Get().ElementAt(2)
                    //}
                },
                new Subject
                {
                    Id = 3,
                    Name = "Моделювання складних систем",
                    SemesterControl = SemesterControlTypes.Credit,
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(3),
                    //    unitOfWork.ClassRepository.Get().ElementAt(4)
                    //}
                },
                new Subject
                {
                    Id = 4,
                    Name = "Основи права та основи конституційного права",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(5),
                    //    unitOfWork.ClassRepository.Get().ElementAt(6)
                    //}
                },
                new Subject
                {
                    Id = 5,
                    Name = "Системи штучного інтелекту",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(7)
                    //}
                },
                new Subject
                {
                    Id = 6,
                    Name = "Чисельні методи математичної фізики",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(8)
                    //}
                },
                new Subject
                {
                    Id = 7,
                    Name = "Програмування під UNIX-подібними системами",
                    SemesterControl = SemesterControlTypes.Exam,
                    PassingDate = new DateTime(2015, 6, 6),
                    //Classes = new List<Class>()
                    //{
                    //    unitOfWork.ClassRepository.Get().ElementAt(9)
                    //}
                }
            };
        }
    }
}
