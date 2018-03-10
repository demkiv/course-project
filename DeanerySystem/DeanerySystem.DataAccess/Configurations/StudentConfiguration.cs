using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class StudentConfiguration : DbEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> entity)
        { 
			//entity.ToTable("Students");
			//entity.HasKey(s => s.Id);
			//entity.Property(s => s.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(s => s.Group)
			    .WithMany(g => g.Students)
                .IsRequired(false)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.SetNull);
            
			entity.HasMany(s => s.ProgressRecords)
			    .WithOne(r => r.Student)
                .IsRequired(true)
                .HasForeignKey(r=>r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(s => s.FailureTickets)
			    .WithOne(w => w.Student)
                .IsRequired(true)
                .HasForeignKey(w=>w.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(s => s.Cellules)
			    .WithOne(w => w.Student)
                .IsRequired(true)
                .HasForeignKey(w=>w.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(s => s.StudentSemesters)
                .WithOne(ssem => ssem.Student)
                .IsRequired(true)
                .HasForeignKey(ssem => ssem.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
