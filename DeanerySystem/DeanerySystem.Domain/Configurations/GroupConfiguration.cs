using DeanerySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Configurations
{
    class GroupConfiguration : EntityTypeConfiguration<Group>
    {
	    public GroupConfiguration() 
		{
			this.ToTable("Groups");
			this.HasKey(g => g.Id);
			this.Property(g => g.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(g => g.Department).WithMany(d => d.Groups);
			this.HasRequired(g => g.Mentor).WithOptional(p => p.MentorOfGroup);

			this.HasMany(g => g.EducationalPlans).WithRequired(p => p.Group);
			this.HasMany(g => g.Students).WithRequired(s => s.Group);
	    }
    }
}
