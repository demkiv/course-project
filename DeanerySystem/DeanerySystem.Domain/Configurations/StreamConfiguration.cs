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
    class StreamConfiguration : EntityTypeConfiguration<Stream>
    {
	    public StreamConfiguration() {
			this.ToTable("Streams");
			this.HasKey(s => s.Id);
			this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(s => s.Faculty).WithMany(f => f.Streams);

			this.HasMany(s => s.Departments).WithRequired(d => d.Stream);
		}
	}
}
