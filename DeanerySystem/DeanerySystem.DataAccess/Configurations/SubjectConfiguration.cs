using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class SubjectConfiguration : DbEntityConfiguration<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> entity)
        {
            entity.ToTable("Subjects");
			entity.HasKey(s => s.Id);
			entity.Property(s => s.Id).ValueGeneratedOnAdd();
            
			entity.HasMany(s => s.EducationalPlans)
			    .WithOne(p => p.Subject)
                .IsRequired(true)
                .HasForeignKey(p=>p.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(s => s.ProgressRecords)
			    .WithOne(r => r.Subject)
                .IsRequired(true)
                .HasForeignKey(r => r.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(s => s.FailureTickets)
			    .WithOne(w => w.Subject)
                .IsRequired(true)
                .HasForeignKey(w => w.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(s => s.Classes)
			    .WithOne(j => j.Subject)
                .IsRequired(true)
                .HasForeignKey(j => j.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
