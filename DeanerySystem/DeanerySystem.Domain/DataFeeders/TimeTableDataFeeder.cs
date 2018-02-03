using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class TimeTableDataFeeder: AbstractDataFeeder<TimeTable>
    {
        public TimeTableDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<TimeTable>
            {
                new TimeTable //щербатий лекція
                {
                    Id = 1,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Integer,
                    Class = unitOfWork.ClassRepository.Get().ElementAt(0)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(5)
                    //}
                },
                //new TimeTable //щербатий лекція // not used
                //{
                //    Id = 2,
                //    DayOfWeek = DayOfWeek.Monday,
                //    Fraction = Fractions.Denominator,

                //    //ClassNumberTimes = new List<ClassNumberTime>
                //    //{
                //    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(5)
                //    //}
                //},
                new TimeTable // право лекція
                {
                    Id = 2,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Numerator,

                    Class = unitOfWork.ClassRepository.Get().ElementAt(1)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(6)
                    //}
                },
                new TimeTable // право практична
                {
                    Id = 3,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Denominator,
                    Class = unitOfWork.ClassRepository.Get().ElementAt(2)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(6)
                    //}
                },
                new TimeTable // мод 42
                {
                    Id = 4,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Numerator,

                    Class = unitOfWork.ClassRepository.Get().ElementAt(3)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(4)
                    //}
                },
                new TimeTable // мод 42
                {
                    Id = 5,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Integer,

                    Class = unitOfWork.ClassRepository.Get().ElementAt(4)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(5)
                    //}
                },
                //new TimeTable // мод 42 // not used
                //{
                //    Id = 7,
                //    DayOfWeek = DayOfWeek.Monday,
                //    Fraction = Fractions.Denominator,

                //    Class = unitOfWork.ClassRepository.Get().ElementAt(0)
                //    //ClassNumberTimes = new List<ClassNumberTime>
                //    //{
                //    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(5)
                //    //}
                //},
                new TimeTable // колос
                {
                    Id = 6,
                    DayOfWeek = DayOfWeek.Tuesday,
                    Fraction = Fractions.Integer,

                    Class = unitOfWork.ClassRepository.Get().ElementAt(7)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(0)
                    //}
                },
                //new TimeTable // колос // not used
                //{
                //    Id = 9,
                //    DayOfWeek = DayOfWeek.Tuesday,
                //    Fraction = Fractions.Denominator,
                //    //ClassNumberTimes = new List<ClassNumberTime>
                //    //{
                //    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(2)
                //    //}
                //},
                new TimeTable // вовк
                {
                    Id = 7,
                    DayOfWeek = DayOfWeek.Tuesday,
                    Fraction = Fractions.Integer,

                    Class = unitOfWork.ClassRepository.Get().ElementAt(8)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(3)
                    //}
                },
                new TimeTable // літик
                {
                    Id = 8,
                    DayOfWeek = DayOfWeek.Tuesday,
                    Fraction = Fractions.Denominator,

                    Class = unitOfWork.ClassRepository.Get().ElementAt(9)
                    //ClassNumberTimes = new List<ClassNumberTime>
                    //{
                    //    unitOfWork.ClassNumberTimeRepository.Get().ElementAt(3)
                    //}
                }
            };
        }
    }
}
