using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class StudentSemesterConfiguration : DbEntityConfiguration<StudentSemester>
    {
        public override void Configure(EntityTypeBuilder<StudentSemester> entity)
        {
            entity.ToTable("StudentSemesters");
            entity.HasKey(ssem => new { ssem.StudentId, ssem.SemesterId });

            entity.HasOne(ssem => ssem.Semester)
                .WithMany(s => s.StudentSemesters)
                .IsRequired(true)
                .HasForeignKey(ssem => ssem.SemesterId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ssem => ssem.Student)
                .WithMany(s => s.StudentSemesters)
                .IsRequired(true)
                .HasForeignKey(ssem => ssem.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
