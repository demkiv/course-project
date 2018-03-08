using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Repositories
{
    public class UniversityRepository : GenericRepository<University>
    {
        public UniversityRepository(DeaneryDbContext contex) : base(contex) { }
    }
}
