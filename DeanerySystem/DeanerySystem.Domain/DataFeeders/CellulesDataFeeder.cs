using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class CellulesDataFeeder: AbstractDataFeeder<Cellule>
    {
        public CellulesDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override List<Cellule> GetData()
        {
            var cellules = new List<Cellule>
            {
                new Cellule
                {
                    Id = 1,
                    Date = new DateTime(2015, 3, 24, 15, 15, 0),
                    Mark = "7",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(1)
                },
                new Cellule
                {
                    Id = 2,
                    Date = new DateTime(2015, 2, 10, 13, 30, 0),
                    Mark = "15",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(2)
                },
                new Cellule
                {
                    Id = 3,
                    Date = new DateTime(2015, 3, 3, 15, 15, 0),
                    Mark = "22",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(4)
                },
                new Cellule
                {
                    Id = 4,
                    Date = new DateTime(2015, 3, 3, 15, 15, 0),
                    Mark = "21",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(8)
                },
                new Cellule
                {
                    Id = 5,
                    Date = new DateTime(2015, 3, 3, 15, 15, 0),
                    Mark = "17",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(10)
                },
                new Cellule
                {
                    Id = 6,
                    Date = new DateTime(2015, 3, 3, 15, 15, 0),
                    Mark = "19",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(14)
                },
                new Cellule
                {
                    Id = 7,
                    Date = new DateTime(2015, 3, 3, 15, 15, 0),
                    Mark = "22",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(11)
                },
                new Cellule
                {
                    Id = 8,
                    Date = new DateTime(2015, 3, 3, 15, 15, 0),
                    Mark = "н",
                    Student = unitOfWork.StudentRepository.Get().ElementAt(4)
                }
            };
            return cellules;
        }
    }
}
