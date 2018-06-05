using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class GroupConfiguration : DbEntityConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> entity)
        {
			entity.ToTable("Groups");
			entity.HasKey(g => g.Id);
			entity.Property(g => g.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(g => g.Department)
			    .WithMany(d => d.Groups)
                .IsRequired(true)
                .HasForeignKey(g=>g.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(g => g.Mentor)
                .WithOne(p => p.MentorOfGroup)
                .IsRequired(false)
                .HasForeignKey<Group>(g => g.MentorId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(g => g.EducationalPlans)
                .WithOne(p => p.Group)
                .IsRequired(true)
                .HasForeignKey(p=>p.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(g => g.Students)
			    .WithOne(s => s.Group)
                .IsRequired(false)
                .HasForeignKey(s=>s.GroupId)
                .OnDelete(DeleteBehavior.SetNull);
            
	    }
    }
}
