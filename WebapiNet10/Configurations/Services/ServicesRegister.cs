using Autofac;
using Autofac.Extensions.DependencyInjection;
using Fawei.Repository.Entities.Shirts;
using System.Reflection;
using Utils.Aspnet.Filters;
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
                options.Filters.Add<GlobalExceptionFilter>();
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
                    Assembly.GetExecutingAssembly(),
                    typeof(IShirtRepository).Assembly
                ));
            });
        }

        private static void RegisterMiddlewares(this WebApplicationBuilder builder)
        {
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //builder.Services.AddApiVersioning()
        }
    }
}
