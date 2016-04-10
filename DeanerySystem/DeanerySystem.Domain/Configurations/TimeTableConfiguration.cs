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
    class TimeTableConfiguration : EntityTypeConfiguration<TimeTable>
    {
	    public TimeTableConfiguration() {
			this.ToTable("TimeTables");
			this.HasKey(t => t.Id);
			this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(t => t.Class).WithMany(j => j.TimeTables);

			this.HasMany(t => t.ClassNumberTimes).WithRequired(t => t.TimeTable);
		}
	}
}
