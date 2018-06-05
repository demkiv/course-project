using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DeanerySystem.DataAccess.Repositories
{
    public class EducationalPlanRepository : GenericRepository<EducationalPlan> 
	{
		public EducationalPlanRepository(DeaneryDbContext context) : base(context) { }

		public override IQueryable<EducationalPlan> Get(Expression<Func<EducationalPlan, bool>> filter = null, 
			Func<IQueryable<EducationalPlan>, IOrderedQueryable<EducationalPlan>> orderBy = null, string includeProperties = "") 
		{
			var educationalPlans = base.Get(filter, orderBy, includeProperties);
			return educationalPlans;
		}
	}
}
