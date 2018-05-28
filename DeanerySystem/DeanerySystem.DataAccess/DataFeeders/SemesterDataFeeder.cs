using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class SemesterDataFeeder : AbstractDataFeeder<Semester>
    {
        public SemesterDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Semester>
            {
                new Semester
                {
                    Id = 1,
                    Number = SemesterNumber.First,
                    Start = new DateTime(2017, 9, 1),
                    CreditSessionStart = new DateTime(2017, 12, 15),
                    End = new DateTime(2017,12,31),
                    SessionStart = new DateTime(2017, 12, 20),
                    SecondWritingStart = new DateTime(2018, 1, 10),
                    ThirdWritingStart = new DateTime(2018, 1, 15)
                }
            };            
        }
    }
}
