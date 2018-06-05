using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public abstract class AbstractDataFeeder<T> : IDataFeeder<T> where T : class
    {
        protected IUnitOfWork unitOfWork;
        protected List<T> data;

        public List<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        protected AbstractDataFeeder(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<T> GetData()
        {
            return this.data;
        }
    }
}

