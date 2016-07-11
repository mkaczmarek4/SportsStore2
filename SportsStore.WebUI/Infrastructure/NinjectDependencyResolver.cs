using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver {
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
            kernel.Bind<IProductRepository>().To<EFProductRepository>();

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            /*mock.Setup(m=>m.Products).Returns(new List <Product>
            {
                new Product { Name = "Piłka nożna", Price = 25},
                new Product { Name = "Piłka nożna", Price = 25 },
                new Product { Name = "Piłka nożna", Price = 25 }
            });

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);*/
        }

    }
    

    }
