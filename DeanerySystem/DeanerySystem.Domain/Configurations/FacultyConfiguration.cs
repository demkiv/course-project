﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Configurations
{
    public class FacultyConfiguration : EntityTypeConfiguration<Faculty>
    {
        public FacultyConfiguration()
        {
            this.ToTable("Faculties");
            this.HasKey(f => f.Id);
			this.Property(f => f.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(f => f.University).WithMany(u => u.Faculties);
			this.HasOptional(f => f.Dean).WithOptionalDependent(p => p.DeanOfFaculty);

            this.HasMany(f => f.Streams).WithRequired(s => s.Faculty);
        }
    }
}
