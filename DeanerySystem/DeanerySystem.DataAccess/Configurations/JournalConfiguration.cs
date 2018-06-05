using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
	class JournalConfiguration : DbEntityConfiguration<Journal> {
	    public override void Configure(EntityTypeBuilder<Journal> entity)
	    {
            entity.ToTable("Journals");
			entity.HasKey(j => j.Id);
			entity.Property(j => j.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(j => j.Class)
			    .WithMany(j => j.Journals)
			    .IsRequired(true)
	            .HasForeignKey(j => j.ClassId)
	            .OnDelete(DeleteBehavior.Cascade); ;
            
			entity.HasMany(j => j.Cellules)
			    .WithOne(c => c.Journal)
	            .IsRequired(true)
	            .HasForeignKey(c=>c.JournalId)
	            .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
