using System.Collections.Generic;
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
                    Group = unitOfWork.GroupRepository.GetById(1),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(1)
                },
                new EducationalPlan()
                {
                    Id = 2,
                    Group = unitOfWork.GroupRepository.GetById(1),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(2)
                },
                new EducationalPlan()
                {
                    Id = 3,
                    Group = unitOfWork.GroupRepository.GetById(2),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(3)
                },
                new EducationalPlan()
                {
                    Id = 4,
                    Group = unitOfWork.GroupRepository.GetById(2),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(4)
                },
                new EducationalPlan()
                {
                    Id = 5,
                    Group = unitOfWork.GroupRepository.GetById(2),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(5)
                },
                new EducationalPlan()
                {
                    Id = 6,
                    Group = unitOfWork.GroupRepository.GetById(2),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(6)
                },
                new EducationalPlan()
                {
                    Id = 7,
                    Group = unitOfWork.GroupRepository.GetById(1),
                    Semester = unitOfWork.SemesterRepository.GetById(1),
                    Subject = unitOfWork.SubjectRepository.GetById(7)
                }
            };

            this.Data.ForEach(e =>
            {
                e.Subject.EducationalPlans.Add(e);
                e.Group.EducationalPlans.Add(e);
                e.Semester.EducationalPlans.Add(e);
            });
        }
    }
}
