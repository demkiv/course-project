using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.DataFeeders
{
    public abstract class AbstractDataFeeder<T> : IDataFeeder<T> where T : class
    {
        protected IUnitOfWork unitOfWork;

        protected AbstractDataFeeder(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public abstract List<T> GetData();
    }
}

