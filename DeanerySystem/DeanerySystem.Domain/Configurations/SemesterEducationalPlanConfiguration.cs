using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations {
	class SemesterEducationalPlanConfiguration : EntityTypeConfiguration<SemesterEducationalPlan> {
		public SemesterEducationalPlanConfiguration() {
			this.ToTable("SemesterEducationalPlans");
			this.HasKey(p => p.Id);
			this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(p => p.Semester).WithRequiredDependent(s => s.SemesterEducationalPlan);
			this.HasRequired(p => p.Group).WithRequiredDependent(g => g.SemesterEducationalPlan);

			this.HasMany(p => p.Subjects).WithRequired(s => s.SemesterEducationalPlan);
		}
	}
}
