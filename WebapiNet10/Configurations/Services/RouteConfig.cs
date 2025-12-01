namespace WebapiNet10.Configurations.Services
{
    public static class RouteConfig
    {
        public static IServiceCollection ConfigureRoute(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = false;
            });
            return services;
        }
    }
}
