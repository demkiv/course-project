using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class DepartmentConfiguration : DbEntityConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> entity)
        {
			entity.ToTable("Departments");
			entity.HasKey(d => d.Id);
			entity.Property(d => d.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Stream)
                .WithMany(s => s.Departments)
                .IsRequired(true)
                .HasForeignKey(d => d.StreamId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(d => d.Head)
                .WithOne(p => p.HeadOfDepartment)
                .IsRequired(false)
                .HasForeignKey<Department>(p => p.HeadId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(d => d.Groups)
                .WithOne(g => g.Department)
                .IsRequired(true)
                .HasForeignKey(g=>g.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(d => d.Professors)
                .WithOne(p => p.Department)
                .IsRequired(false)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
