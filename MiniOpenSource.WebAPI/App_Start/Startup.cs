using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using MiniOpenSource.Data;
using MiniOpenSource.Data.Infrastructure;
using MiniOpenSource.Data.Repositories;
using MiniOpenSource.Service;
using Owin;

[assembly: OwinStartup(typeof(MiniOpenSource.WebAPI.App_Start.Startup))]

namespace MiniOpenSource.WebAPI.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
			ConfigAutofac(app);
		}
		private void ConfigAutofac(IAppBuilder app)
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(Assembly.GetExecutingAssembly());//dki cac controller khi khoi tao
			
			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
			builder.RegisterType<DbFactory>().As<IDBFactory>().InstancePerRequest();
			builder.RegisterType<MiniOSDbContext>().AsSelf().InstancePerRequest();

			// Repositories
			builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces().InstancePerRequest();

			// Services
			builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
			   .Where(t => t.Name.EndsWith("Service"))
			   .AsImplementedInterfaces().InstancePerRequest();

			//gan tat ca cac register vao autofac
			Autofac.IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			//set cho webapi global config
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
		}
	}
}
