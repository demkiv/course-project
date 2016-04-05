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
    class ProfessorConfiguration : EntityTypeConfiguration<Professor>
    {
		public ProfessorConfiguration() 
		{
			this.ToTable("Professors");
			this.HasKey(p => p.Id);
			this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(p => p.Department).WithMany(d => d.Professors);

			this.HasOptional(p => p.Rector).WithRequired(u => u.Rector);
			this.HasOptional(p => p.Dean).WithRequired(f => f.Dean);
			this.HasOptional(p => p.Head).WithRequired(d => d.Head);
			this.HasOptional(p => p.Mentor).WithRequired(g => g.Mentor);

			this.HasMany(p => p.Journals).WithRequired(j => j.Professor);
		}
    }
}
