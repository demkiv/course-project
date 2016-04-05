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
    class CelluleConfiguration : EntityTypeConfiguration<Cellule>
    {
	    public CelluleConfiguration() 
		{
			this.ToTable("Cellules");
			this.HasKey(c => c.Id);
			this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(c => c.Student).WithMany(s => s.Cellules);
			this.HasRequired(c => c.JournalForMarking).WithMany(j => j.Cellules);
		}
    }
}
