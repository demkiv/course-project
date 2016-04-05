using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations {
	class UniversityConfiguration : EntityTypeConfiguration<University> {
		public UniversityConfiguration() {
			this.ToTable("Universities");
			this.HasKey(u => u.Id);
			this.Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(u => u.Rector).WithOptional(u => u.RectorOfUniversity);

			this.HasMany(u => u.Faculties).WithRequired(f => f.University);
		}
	}
}
