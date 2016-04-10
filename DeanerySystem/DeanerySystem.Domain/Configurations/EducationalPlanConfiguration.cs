using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations {
	class EducationalPlanConfiguration : EntityTypeConfiguration<EducationalPlan> {
		public EducationalPlanConfiguration() {
			this.ToTable("EducationalPlans");
			this.HasKey(p => p.Id);
			this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(p => p.Semester).WithMany(s => s.EducationalPlans);
			this.HasRequired(p => p.Group).WithMany(g => g.EducationalPlans);
			this.HasRequired(p => p.Subject).WithMany(g => g.EducationalPlans);
		}
	}
}
