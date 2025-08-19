using log4net.Config;
using log4net;
using System.Reflection;
using WebapiStandard.Configurations.Services;
using WebapiStandard.Configurations.Swagger;
using WebapiStandard.Configrations.Services;
using WebapiStandard.Configrations.Route;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigApiVersion();
//log4net
builder.Logging.AddLog4Net("log4net.config");

// Add services to the container.
builder.AddDbContextRegister();
builder.RegisterServices();
builder.Services.AllowCorsExt();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddSwaggerGenExt();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExt();
}

app.UseHttpsRedirection();
app.UseCorsExt(); // ���� UseRouting ֮��UseAuthorization ֮ǰ
app.UseAuthorization();

app.MapControllers();

app.Run();
