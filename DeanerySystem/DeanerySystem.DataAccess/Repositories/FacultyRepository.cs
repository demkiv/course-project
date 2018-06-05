using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities;

namespace DeanerySystem.DataAccess.Repositories
{
    public class FacultyRepository: GenericRepository<Faculty>
    {
        public FacultyRepository(DeaneryDbContext context): base(context)
        {
            
        }
    }
}
