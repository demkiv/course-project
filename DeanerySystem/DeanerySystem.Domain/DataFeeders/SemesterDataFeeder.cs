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
        }

        public override List<Semester> GetData()
        {
            var semesters = new List<Semester>
            {
                new Semester
                {
                    Id = 1,
                    Number = SemesterNumber.Second,
                    Start = new DateTime(2016, 2, 9),
                    CreditSessionStart = new DateTime(2016, 5, 13)
                }
            };
            return semesters;
        }
    }
}
