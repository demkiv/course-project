using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class CelluleConfiguration : DbEntityConfiguration<Cellule>
    {
        public override void Configure(EntityTypeBuilder<Cellule> entity) 
		{
			entity.ToTable("Cellules");
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).ValueGeneratedOnAdd();

		    entity.HasOne(c => c.Student)
		        .WithMany(s => s.Cellules)
		        .IsRequired(true)
                .HasForeignKey(c => c.StudentId)       
		        .OnDelete(DeleteBehavior.Cascade);

		    entity.HasOne(c => c.Journal)
		        .WithMany(j => j.Cellules)
		        .IsRequired(true)
		        .HasForeignKey(c => c.JournalId)
		        .OnDelete(DeleteBehavior.Cascade);
		}
    }
}
