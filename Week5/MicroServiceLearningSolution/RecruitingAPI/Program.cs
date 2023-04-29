using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repository;
using Recruiting.Infrastructure.Service;
using RecruitingAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS 
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(policy =>
    {
        // AllowAnyOrigin will allow any one to access the API
        // AllowAnyMethod will allow any HTTP method to access the API
        // AllowAnyHeader will allow any headers to access the API
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        // WithOrigins will allow only specific origin to access the API
        // builder.WithOrigins("http://localhost:4200", "http://localhost:4201"))   

        // WithMethods will allow only specific HTTP method to access the API
        // builder.WithMethods("GET", "PUT", "POST", "DELETE");

        // WithHeaders will allow only specific headers to access the API
        // builder.WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header");       
    });
});

// Dbcontext Injection
var connectionstring = Environment.GetEnvironmentVariable("RecruitingAPIDb");
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

// JWT Token Service Injection
builder.Services.AddCustomJwtTokenService();


builder.Services.AddControllers();


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
    // app.UseMiddlewareExtension();

}



app.UseAuthentication();

app.UseRouting();
// put UseAuthorization after UseRouting
app.UseAuthorization();
app.UseCors();
app.UseExceptionMiddleware();
app.MapControllers();



app.Run();


