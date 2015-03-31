using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Concrete
{
    public class EFFacultyRepository: IFacultyRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Faculty> Faculties
        {
            get { return context.Faculties; }
        }
    }
}
