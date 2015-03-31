using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using System.Web.Mvc;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //Mock<IFacultyRepository> mock = new Mock<IFacultyRepository>();
            //mock.Setup(m => m.Faculties).Returns(new List<Faculty> {
            //    new Faculty { Name = "Aplied Math" },
            //    new Faculty { Name = "Math" },
            //    new Faculty { Name = "Physics" }
            //});
            //kernel.Bind<IFacultyRepository>().ToConstant(mock.Object);
            kernel.Bind<IFacultyRepository>().To<EFFacultyRepository>();
        }
        
    }
}