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
    class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
	    public DepartmentConfiguration() 
		{
			this.ToTable("Departments");
			this.HasKey(d => d.Id);
			this.Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(d => d.Stream).WithMany(s => s.Departments);
			this.HasRequired(d => d.Head).WithOptional(p => p.Head);

			this.HasMany(d => d.Groups).WithRequired(g => g.Department);
			this.HasMany(d => d.Professors).WithRequired(p => p.Department);
	    }
    }
}
