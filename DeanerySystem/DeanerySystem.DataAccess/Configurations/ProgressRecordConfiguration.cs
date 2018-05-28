using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class ProgressRecordConfiguration : DbEntityConfiguration<ProgressRecord>
    {
        public override void Configure(EntityTypeBuilder<ProgressRecord> entity)
        {
			entity.ToTable("ProgressRecords");
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(b => b.Student)
			    .WithMany(s => s.ProgressRecords)
			    .IsRequired(true)
			    .HasForeignKey(b => b.StudentId)
			    .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(b => b.Subject)
                .WithMany(s => s.ProgressRecords)
                .IsRequired(true)
                .HasForeignKey(b => b.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
