using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
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
