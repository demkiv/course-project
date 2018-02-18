using System;
using System.Collections.Generic;
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
                new TimeTable 
                {
                    Id = 1,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Integer,
                    Class = unitOfWork.ClassRepository.GetById(1)
                },
                new TimeTable 
                {
                    Id = 2,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Numerator,

                    Class = unitOfWork.ClassRepository.GetById(2)
                },
                new TimeTable 
                {
                    Id = 3,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Denominator,
                    Class = unitOfWork.ClassRepository.GetById(3)
                },
                new TimeTable 
                {
                    Id = 4,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Numerator,

                    Class = unitOfWork.ClassRepository.GetById(4)
                },
                new TimeTable 
                {
                    Id = 5,
                    DayOfWeek = DayOfWeek.Monday,
                    Fraction = Fractions.Integer,

                    Class = unitOfWork.ClassRepository.GetById(5)
                },
                new TimeTable 
                {
                    Id = 6,
                    DayOfWeek = DayOfWeek.Tuesday,
                    Fraction = Fractions.Integer,

                    Class = unitOfWork.ClassRepository.GetById(8)
                },
                new TimeTable
                {
                    Id = 7,
                    DayOfWeek = DayOfWeek.Tuesday,
                    Fraction = Fractions.Integer,

                    Class = unitOfWork.ClassRepository.GetById(9)
                },
                new TimeTable 
                {
                    Id = 8,
                    DayOfWeek = DayOfWeek.Tuesday,
                    Fraction = Fractions.Denominator,

                    Class = unitOfWork.ClassRepository.GetById(10)
                }
            };

            this.Data.ForEach(t=>t.Class.TimeTables.Add(t));
        }
    }
}
