using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class GroupDataFeeder: AbstractDataFeeder<Group>
    {
        public GroupDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override List<Group> GetData()
        {
            var groups = new List<Group>
            {
                new Group
                {
                    Id = 1,
                    Name = "ПМІ-41",
                    //Mentor = entitiesMock.Object.Professors.ElementAt(0),
                    Department = unitOfWork.DepartmentRepository.Get().ElementAt(0),
                    Students = new List<Student>()
                    {
                        unitOfWork.StudentRepository.Get().ElementAt(20),
                        unitOfWork.StudentRepository.Get().ElementAt(21),
                        unitOfWork.StudentRepository.Get().ElementAt(22),
                        unitOfWork.StudentRepository.Get().ElementAt(23),
                        unitOfWork.StudentRepository.Get().ElementAt(24),
                        unitOfWork.StudentRepository.Get().ElementAt(25),
                        unitOfWork.StudentRepository.Get().ElementAt(26),
                        unitOfWork.StudentRepository.Get().ElementAt(27),
                        unitOfWork.StudentRepository.Get().ElementAt(28),
                        unitOfWork.StudentRepository.Get().ElementAt(29),
                        unitOfWork.StudentRepository.Get().ElementAt(30),
                        unitOfWork.StudentRepository.Get().ElementAt(31),
                        unitOfWork.StudentRepository.Get().ElementAt(32),
                        unitOfWork.StudentRepository.Get().ElementAt(33),
                        unitOfWork.StudentRepository.Get().ElementAt(34),
                        unitOfWork.StudentRepository.Get().ElementAt(35),
                        unitOfWork.StudentRepository.Get().ElementAt(36),
                        unitOfWork.StudentRepository.Get().ElementAt(37),
                        unitOfWork.StudentRepository.Get().ElementAt(38),
                        unitOfWork.StudentRepository.Get().ElementAt(39)
                    },
                    //EducationalPlans = new List<EducationalPlan>()
                    //{
                    //	new EducationalPlan() { Semester = entitiesMock.Object.Semesters.ElementAt(0) }
                    //}
                },
                new Group
                {
                    Id = 2,
                    Name = "ПМІ-42",
                    Mentor = unitOfWork.ProfessorRepository.Get().ElementAt(0),
                    Department = unitOfWork.DepartmentRepository.Get().ElementAt(0),
                    Students = new List<Student>()
                    {
                        unitOfWork.StudentRepository.Get().ElementAt(0),
                        unitOfWork.StudentRepository.Get().ElementAt(1),
                        unitOfWork.StudentRepository.Get().ElementAt(2),
                        unitOfWork.StudentRepository.Get().ElementAt(3),
                        unitOfWork.StudentRepository.Get().ElementAt(4),
                        unitOfWork.StudentRepository.Get().ElementAt(5),
                        unitOfWork.StudentRepository.Get().ElementAt(6),
                        unitOfWork.StudentRepository.Get().ElementAt(7),
                        unitOfWork.StudentRepository.Get().ElementAt(8),
                        unitOfWork.StudentRepository.Get().ElementAt(9),
                        unitOfWork.StudentRepository.Get().ElementAt(10),
                        unitOfWork.StudentRepository.Get().ElementAt(11),
                        unitOfWork.StudentRepository.Get().ElementAt(12),
                        unitOfWork.StudentRepository.Get().ElementAt(13),
                        unitOfWork.StudentRepository.Get().ElementAt(14),
                        unitOfWork.StudentRepository.Get().ElementAt(15),
                        unitOfWork.StudentRepository.Get().ElementAt(16),
                        unitOfWork.StudentRepository.Get().ElementAt(17),
                        unitOfWork.StudentRepository.Get().ElementAt(18),
                        unitOfWork.StudentRepository.Get().ElementAt(19)
                    },
                    //EducationalPlans = new List<EducationalPlan>()
                    //{
                    //	new EducationalPlan() { Semester = entitiesMock.Object.Semesters.ElementAt(0) }
                    //}
                }
            };
            return groups;
        }
    }
}
