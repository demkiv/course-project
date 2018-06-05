using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class StreamConfiguration : DbEntityConfiguration<Stream>
    {
        public override void Configure(EntityTypeBuilder<Stream> entity)
        {
			entity.ToTable("Streams");
			entity.HasKey(s => s.Id);
			entity.Property(s => s.Id).ValueGeneratedOnAdd();

			entity.HasOne(s => s.Faculty)
			    .WithMany(f => f.Streams)
                .IsRequired(true)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(s => s.Departments)
                .WithOne(d => d.Stream)
                .IsRequired(true)
                .HasForeignKey(d => d.StreamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
	}
}
