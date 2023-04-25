using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repository;
using Recruiting.Infrastructure.Service;
using RecruitingAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = Environment.GetEnvironmentVariable("RecruitingAPIDb");

// Add services to the container.

// Dbcontext Injection
builder.Services.AddDbContext<RecruitingDbContext>(option =>
{
    // if connection string is not null, use it
    if (connectionstring != null)
    {
        option.UseSqlServer(connectionstring);
    }
    else // if connection string is null, use the default connection string
    {
        // get connection string
        option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingAPIDb"));

    }
    // This will speed up the operation of DB
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository Injection
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddScoped<IJobRequirementRepositoryAsync, JobRequirementRepositoryAsync>();
builder.Services.AddScoped<ISubmissionRepositoryAsync, SubmissionRepositoryAsync>();
builder.Services.AddScoped<ISubmissionStatusRepositoryAsync, SubmissionStatusRepositoryAsync>();

// Service Injection
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();
builder.Services.AddScoped<ISubmissionServiceAsync, SubmissionServiceAsync>();
builder.Services.AddScoped<ISubmissionStatusServiceAsync, SubmissionStatusServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // add exception handler
    app.UseMiddlewareExtension();
}

app.UseAuthorization();

app.MapControllers();


app.Run();

