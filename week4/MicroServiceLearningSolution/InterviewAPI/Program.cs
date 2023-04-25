using System.Data;
using System.Data.SqlClient;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Contract.Services;
using Interview.Infrastructure.Data;
using Interview.Infrastructure.Repository;
using Interview.Infrastructure.Service;
using InterviewAPI.Utility;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Dbcontext Injection
var connectionString = Environment.GetEnvironmentVariable("InterviewAPIDb");

if (string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddTransient<InterviewDbContext>(sp => new InterviewDbContext(builder.Configuration));
}
else
{
    builder.Services.AddScoped<InterviewDbContext>(sp => new InterviewDbContext(new ConfigurationBuilder().AddInMemoryCollection(
        new Dictionary<string, string> { ["ConnectionStrings:InterviewAPIDb"] = connectionString }).Build()));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository Injection
builder.Services.AddScoped<IInterviewsRepositoryAsync, InterviewsRepositoryAsync>();
builder.Services.AddScoped<IInterviewFeedbackRepositoryAsync, InterviewFeedbackRepositoryAsync>();
builder.Services.AddScoped<IInterviewerRepositoryAsync, InterviewerRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();
builder.Services.AddScoped<IRecruiterRepositoryAsync, RecruiterRepositoryAsync>();


// Service Injection
builder.Services.AddScoped<IInterviewsServiceAsync, InterviewsServiceAsync>();
builder.Services.AddScoped<IInterviewFeedbackServiceAsync, InterviewFeedbackServiceAsync>();
builder.Services.AddScoped<IInterviewerServiceAsync, InterviewerServiceAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();
builder.Services.AddScoped<IRecruiterServiceAsync, RecruiterServiceAsync>();


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

