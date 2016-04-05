using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations {
	class JournalForMarkingConfiguration : EntityTypeConfiguration<JournalForMarking> {
		public JournalForMarkingConfiguration() {
			this.ToTable("JournalsForMarking");
			this.HasKey(j => j.Id);
			this.Property(j => j.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(j => j.Journal).WithMany(j => j.JournalsForMarking);

			this.HasMany(j => j.Cellules).WithRequired(c => c.JournalForMarking);
		}
	}
}
