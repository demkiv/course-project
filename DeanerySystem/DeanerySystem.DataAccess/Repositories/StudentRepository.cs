using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DeanerySystem.DataAccess.Repositories
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(DeaneryDbContext context) : base(context)
        {

        }

        public override IQueryable<Student> Get(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, string includeProperties = "")
        {
            var students = base.Get(filter, orderBy, includeProperties);
            students.Include(s => s.Group).ThenInclude(g => g.Department).ThenInclude(d => d.Stream).ThenInclude(s => s.Faculty);
            return students;
        }
    }
}
