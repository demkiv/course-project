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
    class SemesterConfiguration : EntityTypeConfiguration<Semester>
    {
		public SemesterConfiguration() 
		{
			this.ToTable("Semesters");
			this.HasKey(s => s.Id);
			this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(s => s.SemesterEducationalPlan).WithRequiredPrincipal(p => p.Semester);

			this.HasMany(s => s.Students).WithMany(s => s.Semesters).Map(ss => {
				ss.MapLeftKey("SemesterId");
				ss.MapRightKey("StudentId");
				ss.ToTable("StudentsSemesters");
			});
		}
    }
}
