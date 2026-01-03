using Fawei.Repository;
using Fawei.Repository.Core.Configurations;
using Fawei.Repository.Entities.Shirts;
using Logging;
using Utils.Aspnet.Configurations;
using Utils.Aspnet.Configurations.Swagger;
using WebapiNet10.Configurations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.NetCoreLoggingSetup(Path.Combine("logs", builder.Environment.ApplicationName));
builder.AddSqlServerContext<ShirtsDbContext>("Net10DemoDb");

builder.ConfigApiVersion();

// Add services to the container.
builder.RegisterCommonServices();
builder.RegisterServices();
builder.Services.AllowCorsExt();
builder.AddSwaggerGenExt($"{typeof(Program).Assembly.GetName().Name}.xml");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerExt();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
