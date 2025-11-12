using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Utils.Ioc;
using WebapiStandard.Configurations.Route;
using WebapiStandard.Constants;
using WebapiStandard.Filters;
using WebapiStandard.Services.Auth;

namespace WebapiStandard.Configurations.Services
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.UseAutofac();
            builder.Services.AddSignalR();
            builder.Services.AddHttpContextAccessor();
            // JWT Authentication
            RegisterJwt(builder);
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddControllers(options =>
            {
                options.AddControllerPrefix();
                options.Filters.Add<GlobalExceptionFilter>();
            });
            //.AddJsonOptions(option =>
            //{
            //    option.JsonSerializerOptions.Converters.Add(new QueryExpressionValueConverter());
            //});
        }

        private static void UseAutofac(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // 配置Autofac容器
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                // 注册我们的批量注册模块
                containerBuilder.RegisterModule(new AutoRegisterModule(
                    Assembly.GetExecutingAssembly(),
                    // 可以添加更多需要扫描的程序集
                    Assembly.Load("SaiouService"),
                    Assembly.Load("React.Study")
                ));

                // 这里可以添加其他手动注册
                // containerBuilder.RegisterType<ManualRegisteredService>().As<IManualRegisteredService>();
            });
        }

        private static void RegisterJwt(WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            //ValidIssuer = ProjectConstants.JwtIssuer,
            //            //ValidAudience = ProjectConstants.JwtAudience,
            //            //IssuerSigningKey = ProjectConstants.GetSymmetricSecurityKey()
            //        };
            //    });
        }

        private static void AddControllerPrefix(this MvcOptions options)
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
