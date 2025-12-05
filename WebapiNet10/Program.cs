using Fawei.Repository;
using Fawei.Repository.Core.Configurations;
using Logging;
using WebapiNet10.Configurations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLog4Net("log4net.config");
builder.AddSqlServerContext<ShirtsDbContext>(builder.Configuration.GetConnectionString("Net10DemoDb"));

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
