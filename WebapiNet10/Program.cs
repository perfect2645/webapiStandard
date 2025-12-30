using Fawei.Repository;
using Fawei.Repository.Core.Configurations;
using Logging;
using System.Reflection;
using Utils.Aspnet.Configurations;
using WebapiNet10.Configurations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.NetCoreLoggingSetup(Path.Combine("logs", builder.Environment.ApplicationName));
builder.AddSqlServerContext<ShirtsDbContext>("Net10DemoDb");

// Add services to the container.
builder.RegisterServices();
builder.Services.AllowCorsExt();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Webapi demo v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
