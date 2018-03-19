using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class EducationalPlan : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
