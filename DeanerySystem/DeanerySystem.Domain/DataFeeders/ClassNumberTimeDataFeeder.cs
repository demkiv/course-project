using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class ClassNumberTimeDataFeeder: AbstractDataFeeder<ClassNumberTime>
    {
        public ClassNumberTimeDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<ClassNumberTime>
            {
                new ClassNumberTime()
                {
                    Id = 1,
                    Number = 1,
                    Start = new TimeSpan(0, 8, 30, 0, 0),
                    End = new TimeSpan(0, 9, 50, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(6)
                },
                new ClassNumberTime()
                {
                    Id = 2,
                    Number = 2,
                    Start = new TimeSpan(0, 10, 10, 0, 0),
                    End = new TimeSpan(0, 11, 30, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(1)
                },
                new ClassNumberTime()
                {
                    Id = 3,
                    Number = 3,
                    Start = new TimeSpan(0, 11, 50, 0, 0),
                    End = new TimeSpan(0, 13, 10, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(4)
                },
                new ClassNumberTime()
                {
                    Id = 4,
                    Number = 4,
                    Start = new TimeSpan(0, 13, 30, 0, 0),
                    End = new TimeSpan(0, 14, 50, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(5)
                },
                new ClassNumberTime()
                {
                    Id = 5,
                    Number = 5,
                    Start = new TimeSpan(0, 15, 15, 0, 0),
                    End = new TimeSpan(0, 16, 25, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(6)
                },
                new ClassNumberTime()
                {
                    Id = 6,
                    Number = 6,
                    Start = new TimeSpan(0, 16, 40, 0, 0),
                    End = new TimeSpan(0, 18, 0, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(1)
                },
                new ClassNumberTime()
                {
                    Id = 7,
                    Number = 7,
                    Start = new TimeSpan(0, 18, 10, 0, 0),
                    End = new TimeSpan(0, 19, 30, 0, 0),
                    TimeTable = unitOfWork.TimeTableRepository.GetById(2)
                }
            };
        }
    }
}
