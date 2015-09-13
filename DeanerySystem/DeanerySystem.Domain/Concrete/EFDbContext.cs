using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using System.Data.Entity;

namespace DeanerySystem.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<FacultyExample> Faculties { get; set; }
    }
}
