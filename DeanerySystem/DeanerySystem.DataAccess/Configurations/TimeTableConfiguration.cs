using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class TimeTableConfiguration : DbEntityConfiguration<TimeTable>
    {
        public override void Configure(EntityTypeBuilder<TimeTable> entity) { 
			entity.ToTable("TimeTables");
			entity.HasKey(t => t.Id);
			entity.Property(t => t.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(t => t.Class)
			    .WithMany(j => j.TimeTables)
                .IsRequired(true)
                .HasForeignKey(t=>t.ClassId).
                OnDelete(DeleteBehavior.Cascade);
            
			entity.HasMany(t => t.ClassNumberTimes)
			    .WithOne(t => t.TimeTable)
                .IsRequired(true)
                .HasForeignKey(t => t.TimeTableId)
                .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
