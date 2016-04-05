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
    class ClassNumberTimeConfiguration : EntityTypeConfiguration<ClassNumberTime>
    {
	    public ClassNumberTimeConfiguration() 
		{
			this.ToTable("ClassNumberTimes");
			this.HasKey(t => t.Id);
			this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(t => t.TimeTable).WithMany(tt => tt.ClassNumberTimes);
	    }
    }
}
