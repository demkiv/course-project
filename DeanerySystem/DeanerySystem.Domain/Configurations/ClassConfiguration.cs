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
    class ClassConfiguration : EntityTypeConfiguration<Class> {
	    public ClassConfiguration() {
			this.ToTable("Classes");
			this.HasKey(j => j.Id);
			this.Property(j => j.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(j => j.Professor).WithMany(p => p.Classes);
			this.HasRequired(j => j.Subject).WithMany(s => s.Classes);

			this.HasMany(j => j.Journals).WithRequired(j => j.Class);
			this.HasMany(j => j.TimeTables).WithRequired(t => t.Class);
		}
	}
}
