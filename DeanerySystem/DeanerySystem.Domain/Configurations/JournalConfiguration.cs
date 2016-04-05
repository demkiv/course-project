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
    class JournalConfiguration : EntityTypeConfiguration<Journal> {
	    public JournalConfiguration() {
			this.ToTable("Journals");
			this.HasKey(j => j.Id);
			this.Property(j => j.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(j => j.Professor).WithMany(p => p.Journals);
			this.HasRequired(j => j.Subject).WithMany(s => s.Journals);

			this.HasMany(j => j.JournalsForMarking).WithRequired(j => j.Journal);
			this.HasMany(j => j.TimeTables).WithRequired(t => t.Journal);
		}
	}
}
