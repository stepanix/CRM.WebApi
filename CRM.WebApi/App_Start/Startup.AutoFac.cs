using Autofac;
using AutoMapper;
using Autofac.Integration.WebApi;
using CRM.Domain.Repositories;
using CRM.EntityFramework;
using CRM.EntityFramework.Repositories.Base;
using System;
using Owin;
using System.Reflection;
using CRM.Domain;
using CRM.Domain.RequestIdentity;
using System.Web.Http;

namespace CRM.WebApi.App_Start
{
    public partial class Startup
    {
        public void ConfigureAutoFac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register up the Request Identity Provider
            builder.RegisterType<RequestIdentityProvider>().As<IRequestIdentityProvider>().InstancePerRequest();

            // Logging
            //builder.RegisterType<ILogger>().AsSelf().InstancePerRequest();

            // Register module for different layers
            builder.RegisterModule(new DtoMapperModule());
            builder.RegisterModule(new DomainMapperModule());

            // AutoMapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            //Register Generic Repository
            builder.RegisterGeneric(typeof(ORMBaseRepository<,>))
                       .As(typeof(IBaseRepository<>))
                       .InstancePerRequest();

            //Scan Any Repository For Registration
            builder.RegisterAssemblyTypes(assemblies)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();

            //Scan Any Service For Registration
            builder.RegisterAssemblyTypes(assemblies)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces();
            //builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<DataContext>().InstancePerRequest();


            // Register method interceptor module
            //builder.RegisterModule(new InterceptModule());

            // Build and Resolve
            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;

            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            app.UseAutofacWebApi(GlobalConfiguration.Configuration);
        }
    }
}