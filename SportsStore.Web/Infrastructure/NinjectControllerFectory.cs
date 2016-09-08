using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SportsStore.Domain.Abstruct;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using Moq;
using SportsStore.Web.Infrastructure.Abstruct;
using SportsStore.Web.Infrastructure.Cincrete;

namespace SportsStore.Web.Infrastructure
{
    public class NinjectControllerFectory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFectory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            _ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}