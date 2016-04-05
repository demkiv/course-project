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
    class StudentConfiguration : EntityTypeConfiguration<Student>
    {
	    public StudentConfiguration() {
			this.ToTable("Students");
			this.HasKey(s => s.Id);
			this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(s => s.Group).WithMany(g => g.Students);

			this.HasMany(s => s.ProgressRecords).WithRequired(r => r.Student);
			this.HasMany(s => s.Writings).WithRequired(w => w.Student);
			this.HasMany(s => s.Cellules).WithRequired(w => w.Student);

			this.HasMany(s => s.Semesters).WithMany(s => s.Students).Map(ss => {
				ss.MapRightKey("StudentId");
				ss.MapRightKey("SemesterId");				
				ss.ToTable("StudentsSemesters");
			});
		}
	}
}
