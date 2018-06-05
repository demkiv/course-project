using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class UniversityConfiguration : DbEntityConfiguration<University>
    {
        public override void Configure(EntityTypeBuilder<University> entity)
        { 
			entity.ToTable("Universities");
			entity.HasKey(u => u.Id);
			entity.Property(u => u.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(u => u.Rector)
			    .WithOne(u => u.RectorOfUniversity)
                .IsRequired(false)
			    .HasForeignKey<University>(u=>u.RectorId)
			    .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(u => u.Faculties)
                .WithOne(f => f.University)
                .IsRequired(true)
                .HasForeignKey(f => f.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
