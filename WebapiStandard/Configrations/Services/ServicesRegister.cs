using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using WebapiStandard.Configurations.Route;
using WebapiStandard.Constants;
using WebapiStandard.Models.Auth;
using WebapiStandard.Services.Auth;

namespace WebapiStandard.Configurations.Services
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSignalR();
            // JWT Authentication
            RegisterJwt(builder);
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddControllers(options =>
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
