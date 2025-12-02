using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Utils.Ioc;

namespace WebapiNet10.Configurations.Services
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.UseAutofac();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers(options =>
            {
                //options.Filters.Add<GlobalExcetionFilter>()
            });

            builder.RegisterMiddlewares();
            builder.Services.ConfigureRoutes();
        }

        private static void UseAutofac(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new AutoRegisterModule(
                    Assembly.GetExecutingAssembly()
                    //typeof(IShirtService).Assembly,
                ));
            });
        }

        private static void RegisterMiddlewares(this WebApplicationBuilder builder)
        {
            // Register middlewares here if needed
        }
    }
}
