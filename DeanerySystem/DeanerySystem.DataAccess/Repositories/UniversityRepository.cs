using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities;

namespace DeanerySystem.DataAccess.Repositories
{
    public class UniversityRepository : GenericRepository<University>
    {
        public UniversityRepository(DeaneryDbContext contex) : base(contex) { }
    }
}
