using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.Infrastructure.Data;
using Onboarding.Infrastructure.Repository;
using Onboarding.Infrastructure.Service;
using OnboardingAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS
builder.Services.AddCors(options =>
{   
    options.AddDefaultPolicy( policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
     
    });
});

var connectionstring = Environment.GetEnvironmentVariable("OnboardingAPIDb");
// Dbcontext Injection
builder.Services.AddDbContext<OnboardingDbContext>(option =>
{
    if (connectionstring != null)
    {
        option.UseSqlServer(connectionstring);
    }
    else
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("OnboardingAPIDb"));
    }
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository Injection
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IEmployeeCategoryRepositoryAsync, EmployeeCategoryRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRoleRepositoryAsync, EmployeeRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeStatusRepositoryAsync, EmployeeStatusRepositoryAsync>();

// Service Injection
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IEmployeeCategoryServiceAsync, EmployeeCategoryServiceAsync>();
builder.Services.AddScoped<IEmployeeRoleServiceAsync, EmployeeRoleServiceAsync>();
builder.Services.AddScoped<IEmployeeStatusServiceAsync, EmployeeStatusServiceAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddlewareExtension();
}

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();

