using Application.Interfaces;
using Application.Services;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
const string Policy = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{env}.json")
    .Build();
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddDbContextPool<ApplicationDbContext>(cfg => 
{   
    cfg.UseNpgsql(builder.Configuration[$"ConnectionStrings:{env}"], b => b.MigrationsAssembly("WebApi"));
});

builder.Services.AddCors(cfg => {
    cfg.AddPolicy(name: Policy, config => {
        config.WithOrigins("http://localhost:8001")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
};

app.UseCors(Policy);

app.MapControllers();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
