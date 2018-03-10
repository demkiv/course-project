using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class ProfessorConfiguration : DbEntityConfiguration<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> entity)
        {
			//entity.ToTable("Professors");
			//entity.HasKey(p => p.Id);
			//entity.Property(p => p.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(p => p.Department)
			    .WithMany(d => d.Professors)
			    .IsRequired(false)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
			entity.HasOne(p => p.RectorOfUniversity)
			    .WithOne(u => u.Rector)
                .IsRequired(false)
                .HasForeignKey<University>(p => p.RectorId)
                .OnDelete(DeleteBehavior.SetNull);
			entity.HasOne(p => p.DeanOfFaculty)
			    .WithOne(f => f.Dean)
                .IsRequired(false)
                .HasForeignKey<Faculty>(p => p.DeanId)
                .OnDelete(DeleteBehavior.SetNull);
			entity.HasOne(p => p.MentorOfGroup)
			    .WithOne(g => g.Mentor)
                .IsRequired(false)
                .HasForeignKey<Group>(p => p.MentorId)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(p => p.HeadOfDepartment).
                WithOne(d => d.Head)
                .HasForeignKey<Department>(d => d.HeadId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            
			entity.HasMany(p => p.Classes)
			    .WithOne(j => j.Professor)
                .IsRequired(true)
                .HasForeignKey(c=>c.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
		}
    }
}
