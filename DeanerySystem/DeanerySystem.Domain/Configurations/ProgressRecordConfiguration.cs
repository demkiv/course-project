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
    class ProgressRecordConfiguration : EntityTypeConfiguration<ProgressRecord>
    {
		public ProgressRecordConfiguration() 
		{
			this.ToTable("ProgressRecorsds");
			this.HasKey(p => p.Id);
			this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(b => b.Student).WithMany(s => s.ProgressRecords);
			this.HasRequired(b => b.Subject).WithMany(s => s.ProgressRecords);
		}
    }
}
