using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class EducationalPlanConfiguration : DbEntityConfiguration<EducationalPlan>
    {
        public override void Configure(EntityTypeBuilder<EducationalPlan> entity)
        {
			entity.ToTable("EducationalPlans");
			entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(p => p.Semester)
			    .WithMany(s => s.EducationalPlans)
			    .IsRequired(true)
			    .HasForeignKey(p=>p.SemesterId)
			    .OnDelete(DeleteBehavior.Cascade);
			entity.HasOne(p => p.Group)
			    .WithMany(g => g.EducationalPlans)
			    .IsRequired(true)
			    .HasForeignKey(p => p.GroupId)
			    .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(p => p.Subject)
                .WithMany(g => g.EducationalPlans)
                .IsRequired(true)
                .HasForeignKey(p => p.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
