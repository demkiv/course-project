using System.ComponentModel.DataAnnotations.Schema;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class ClassConfiguration : DbEntityConfiguration<Class> {
        public override void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.ToTable("Classes");
			entity.HasKey(j => j.Id);
			entity.Property(j => j.Id).ValueGeneratedOnAdd();

            entity.HasOne(j => j.Professor)
                .WithMany(p => p.Classes)
                .IsRequired(false)
                .HasForeignKey(j => j.ProfessorId)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(j => j.Subject)
                .WithMany(s => s.Classes)
                .IsRequired(true)
                .HasForeignKey(j => j.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(c => c.Journals)
                .WithOne(j => j.Class)
                .IsRequired(true)
                .HasForeignKey(j => j.ClassId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(c => c.TimeTables)
                .WithOne(t => t.Class)
                .IsRequired(true)
                .HasForeignKey(t => t.ClassId)
                .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
