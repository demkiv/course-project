using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    internal class FacultyConfiguration : DbEntityConfiguration<Faculty>
    {
        public override void Configure(EntityTypeBuilder<Faculty> entity)
        {
            entity.ToTable("Faculties");
            entity.HasKey(f => f.Id);
			entity.Property(f => f.Id).ValueGeneratedOnAdd();

            entity.HasOne(f => f.University)
                .WithMany(u => u.Faculties)
                .IsRequired(true)
                .HasForeignKey(f => f.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(f => f.Dean)
                .WithOne(p => p.DeanOfFaculty)
                .IsRequired(false)
                .HasForeignKey<Faculty>(f => f.DeanId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(f => f.Streams)
                .WithOne(s => s.Faculty)
                .IsRequired(true)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
