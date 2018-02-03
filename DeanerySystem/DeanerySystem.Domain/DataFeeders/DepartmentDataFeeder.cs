using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class DepartmentDataFeeder : AbstractDataFeeder<Department>
    {
        public DepartmentDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var stream = this.unitOfWork.StreamRepository.GetById(1);
            this.data = new List<Department>
            {
                new Department()
                {
                    Id = 1,
                    Name = "Програмування",
                    Number = 1,
                    Stream = stream
                },
                new Department()
                {
                    Id = 2,
                    Name = "Інформаційних систем",
                    Number = 2,
                    Stream = stream
                },
                new Department()
                {
                    Id = 3,
                    Name = "Дискретного аналізу та інтелектуальних систем",
                    Number = 3,
                    Stream = stream
                }
            };
        }
    }
}
