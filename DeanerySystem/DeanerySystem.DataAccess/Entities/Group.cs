using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.Entities
{
    public class Group : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tuitions Tuition { get; set; }

        public int DepartmentId { get; set; }
        public Guid? MentorId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Professor Mentor { get; set; }
        public virtual ICollection<EducationalPlan> EducationalPlans { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public Group()
        {
            this.EducationalPlans = new List<EducationalPlan>();
            this.Students = new List<Student>();
        }
    }
}
