using Logging;
using WebapiNet10.Configurations.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Logging.AddLog4Net("log4net.config");

Log4Logger.Logger.Debug("debug1");
Log4Logger.Logger.Warn("warn3");
// Add services to the container.
builder.RegisterServices();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
