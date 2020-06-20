using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.Concrete;
using Moq;
using Ninject;

namespace BookStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType) => kernel.TryGet(serviceType);
        public IEnumerable<object> GetServices(Type serviceType) => kernel.GetAll(serviceType);
        private void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<IDeliveryDetailsRepository>().To<EFDeliveryDetailsRepository>();
            kernel.Bind<IOrderProcessorDb>().To<DbOrderProcessor>();
            var emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
            //kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}