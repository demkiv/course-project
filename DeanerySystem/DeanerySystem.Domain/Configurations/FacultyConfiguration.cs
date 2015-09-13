using System;
using System.Collections.Generic;
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
            this.HasRequired(f => f.Dean).WithOptional(p => p.DeanFaculty);
            this.HasMany(f => f.Streams).WithRequired(s => s.Faculty);
        }
    }
}
