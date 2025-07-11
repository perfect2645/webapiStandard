using Microsoft.AspNetCore.Mvc;
using WebapiStandard.Configurations.Route;
using WebapiStandard.Constants;

namespace WebapiStandard.Configurations.Services
{
    public static class ServicesRegister
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllers(options =>
            {
                options.AddControllerPrifx();
            });
            //services.AddControllers(option =>
            //{
            //    option.Filters.Add<ExceptionFilterAttribute>();
            //}).AddJsonOptions(option =>
            //{
            //    option.JsonSerializerOptions.Converters.Add(new QueryExpressionValueConverter());
            //});
        }

        private static void AddControllerPrifx(this MvcOptions options)
        {
            options.Conventions.Insert(0, new RouteConvention(new RouteAttribute(ProjectConstants.RoutePrefix)));
        }

        public static void AllowCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }
    }
}
