using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class EducationalPlanDataFeeder: AbstractDataFeeder<EducationalPlan>
    {
        public EducationalPlanDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<EducationalPlan>
            {
                new EducationalPlan()
                {
                    Id = 1,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(0),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(0)
                },
                new EducationalPlan()
                {
                    Id = 2,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(0),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(1)
                },
                new EducationalPlan()
                {
                    Id = 3,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(1),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(2)
                },
                new EducationalPlan()
                {
                    Id = 4,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(1),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(3)
                },
                new EducationalPlan()
                {
                    Id = 5,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(1),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(4)
                },
                new EducationalPlan()
                {
                    Id = 6,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(1),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(5)
                },
                new EducationalPlan()
                {
                    Id = 7,
                    Group = unitOfWork.GroupRepository.Get().ElementAt(0),
                    Semester = unitOfWork.SemesterRepository.Get().ElementAt(0),
                    Subject = unitOfWork.SubjectRepository.Get().ElementAt(6)
                }
            };
        }
    }
}
