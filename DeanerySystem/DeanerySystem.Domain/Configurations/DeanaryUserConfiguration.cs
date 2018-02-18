using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Identity;

namespace DeanerySystem.Domain.Configurations
{
    class DeanaryUserConfiguration : EntityTypeConfiguration<DeaneryUser>
    {
		public DeanaryUserConfiguration() 
		{
			this.ToTable("DeaneryUsers");
            this.HasKey(du => du.Id);
            this.Property(du => du.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
