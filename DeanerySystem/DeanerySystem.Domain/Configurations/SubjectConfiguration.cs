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
    class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
	    public SubjectConfiguration() {
			this.ToTable("Subjects");
			this.HasKey(s => s.Id);
			this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasMany(s => s.EducationalPlans).WithRequired(p => p.Subject);
			this.HasMany(s => s.ProgressRecords).WithRequired(r => r.Subject);
			this.HasMany(s => s.FailureTickets).WithRequired(w => w.Subject);
			this.HasMany(s => s.Classes).WithRequired(j => j.Subject);
		}
	}
}
