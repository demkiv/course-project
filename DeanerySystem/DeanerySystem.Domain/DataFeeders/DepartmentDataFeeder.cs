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
        }

        public override List<Department> GetData()
        {
            var departments = new List<Department>
            {
                new Department()
                {
                    Id = 1,
                    Name = "Інформаційні системи",
                    //Head = entitiesMock.Object.Professors.ElementAt(1),
                    Number = 2,
                    Stream = unitOfWork.StreamRepository.Get().First(x => x.Id == 1)
                }
            };
            return departments;
        }
    }
}
