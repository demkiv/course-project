using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class ClassNumberTimeConfiguration : DbEntityConfiguration<ClassNumberTime>
    {
        public override void Configure(EntityTypeBuilder<ClassNumberTime> entity)
        {
			entity.ToTable("ClassNumberTimes");
			entity.HasKey(t => t.Id);
			entity.Property(t => t.Id).ValueGeneratedOnAdd();

            entity.HasOne(t => t.TimeTable)
                .WithMany(tt => tt.ClassNumberTimes)
                .IsRequired(true)
                .HasForeignKey(t => t.TimeTableId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
