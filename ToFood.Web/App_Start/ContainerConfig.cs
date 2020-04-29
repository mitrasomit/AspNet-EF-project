using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfigaration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>()
                   .As<IRestaurantData>()
                   .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfigaration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}