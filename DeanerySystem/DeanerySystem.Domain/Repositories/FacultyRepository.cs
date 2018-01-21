using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Repositories
{
    public class FacultyRepository: GenericRepository<Faculty>
    {
        public FacultyRepository(DeaneryDbContext context): base(context)
        {
            
        }
    }
}
