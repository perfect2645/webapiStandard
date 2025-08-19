namespace WebapiStandard.Configrations.Route
{
    public static class CorsConfig
    {
        public static void AllowCorsExt(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // 前端地址
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials(); // 如果前端发送凭据（如cookies）
                });
            });
        }
        public static void UseCorsExt(this IApplicationBuilder app)
        {
            app.UseCors("AllowReactApp");
        }
    }
}
