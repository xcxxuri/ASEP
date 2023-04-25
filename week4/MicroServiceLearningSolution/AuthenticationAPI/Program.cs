using Authentication.Infrastructure.Data;
using AuthenticationAPI.Utility;
using Microsoft.EntityFrameworkCore;
using Authentication.Infrastructure.Repository;
using Authentication.Infrastructure.Service;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Contract.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionstring = Environment.GetEnvironmentVariable("AuthenticationAPIDb");
// Add DbContext using SQL Server Provider
builder.Services.AddDbContext<AuthenticationDbContext>(option =>
{
    if (connectionstring != null)
    {
        option.UseSqlServer(connectionstring);
    }
    else
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationAPIDb"));
    }
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository Injection
builder.Services.AddScoped<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();
builder.Services.AddScoped<IAccountRepositoryAsync, AccountRepositoryAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();

// Service Injection
builder.Services.AddScoped<IUserRoleServiceAsync, UserRoleServiceAsync>();
builder.Services.AddScoped<IAccountServiceAsync, AccountServiceAsync>();
builder.Services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseMiddlewareExtension();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

