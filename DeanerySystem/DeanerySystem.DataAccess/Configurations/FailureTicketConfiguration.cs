using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeanerySystem.DataAccess.Configurations
{
    class FailureTicketConfiguration : DbEntityConfiguration<FailureTicket>
    {
        public override void Configure(EntityTypeBuilder<FailureTicket> entity)
        {
            entity.ToTable("FailureTickets");
			entity.HasKey(w => w.Id);
			entity.Property(w => w.Id).ValueGeneratedOnAdd();
            
			entity.HasOne(w => w.Student)
			    .WithMany(s => s.FailureTickets)
                .IsRequired(true)
                .HasForeignKey(w=>w.StudentId)
			    .OnDelete(DeleteBehavior.Cascade);
			entity.HasOne(w => w.Subject)
			    .WithMany(s => s.FailureTickets)
                .IsRequired(true)
                .HasForeignKey(w => w.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
