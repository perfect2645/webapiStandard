namespace WebapiNet10.Configurations.Services
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            //builder.UseAutofac();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers(options =>
            {

            });
        }
    }
}
