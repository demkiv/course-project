using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations
{
    class FailureTicketConfiguration : EntityTypeConfiguration<FailureTicket>
    {
	    public FailureTicketConfiguration() {
			this.ToTable("FailureTickets");
			this.HasKey(w => w.Id);
			this.Property(w => w.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(w => w.Student).WithMany(s => s.FailureTickets);
			this.HasRequired(w => w.Subject).WithMany(s => s.FailureTickets);
		}
	}
}
