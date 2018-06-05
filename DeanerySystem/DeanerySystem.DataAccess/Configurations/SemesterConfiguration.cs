using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class SemesterConfiguration : DbEntityConfiguration<Semester>
    {
        public override void Configure(EntityTypeBuilder<Semester> entity)
        {
			entity.ToTable("Semesters");
			entity.HasKey(s => s.Id);
			entity.Property(s => s.Id).ValueGeneratedOnAdd();
            
			entity.HasMany(s => s.EducationalPlans)
			    .WithOne(p => p.Semester)
                .IsRequired(true)
                .HasForeignKey(p=>p.SemesterId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(s => s.StudentSemesters)
                .WithOne(ssem => ssem.Semester)
                .IsRequired(true)
                .HasForeignKey(ssem => ssem.SemesterId)
                .OnDelete(DeleteBehavior.Cascade);
		}
    }
}
