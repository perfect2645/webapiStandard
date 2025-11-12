using Db.React.Study.Configurations.Data;
using Logging;
using Microsoft.EntityFrameworkCore;
using Utils.Reflection;

namespace WebapiStandard.Configrations.Services
{
    public static class DbContextRegister
    {
        public static void AddDbContextRegister(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                //Data Source=DESKTOP-XICHENG\FAWEISQLEXPRESS;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
