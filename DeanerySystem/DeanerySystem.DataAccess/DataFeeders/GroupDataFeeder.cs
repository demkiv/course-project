using System.Collections.Generic;
using System.Linq;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class GroupDataFeeder: DataAccess.DataFeeders.AbstractDataFeeder<Group>
    {
        public GroupDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Group>
            {
                new Group
                {
                    Id = 1,
                    Name = "ПМІ-61",
                    Mentor = unitOfWork.ProfessorRepository.Get().ToList().ElementAt(17),              
                    Department = unitOfWork.DepartmentRepository.GetById(1),
                },
                new Group
                {
                    Id = 2,
                    Name = "ПМІ-62",
                    Mentor = unitOfWork.ProfessorRepository.Get().ToList().ElementAt(1),
                    Department = unitOfWork.DepartmentRepository.GetById(2),
                },
                new Group
                {
                    Id = 2,
                    Name = "ПМІ-63",
                    Mentor = unitOfWork.ProfessorRepository.Get().ToList().ElementAt(0),
                    Department = unitOfWork.DepartmentRepository.GetById(3),
                }
            };

            this.Data.ForEach(g=>g.Department.Groups.Add(g));
        }
    }
}
