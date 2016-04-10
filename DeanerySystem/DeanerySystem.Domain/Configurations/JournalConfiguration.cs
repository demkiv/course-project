using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations {
	class JournalConfiguration : EntityTypeConfiguration<Journal> {
		public JournalConfiguration() {
			this.ToTable("Journals");
			this.HasKey(j => j.Id);
			this.Property(j => j.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(j => j.Class).WithMany(j => j.Journals);

			this.HasMany(j => j.Cellules).WithRequired(c => c.Journal);
		}
	}
}
