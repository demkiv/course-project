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
    class WritingConfiguration : EntityTypeConfiguration<Writing>
    {
	    public WritingConfiguration() {
			this.ToTable("Writings");
			this.HasKey(w => w.Id);
			this.Property(w => w.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(w => w.Student).WithMany(s => s.Writings);
			this.HasRequired(w => w.Subject).WithMany(s => s.Writings);
		}
	}
}
