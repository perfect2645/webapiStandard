namespace WebapiStandard.Configurations.Services
{
    public static class ServicesRegister
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllers();
            //services.AddControllers(option =>
            //{
            //    option.Filters.Add<ExceptionFilterAttribute>();
            //}).AddJsonOptions(option =>
            //{
            //    option.JsonSerializerOptions.Converters.Add(new QueryExpressionValueConverter());
            //});
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
