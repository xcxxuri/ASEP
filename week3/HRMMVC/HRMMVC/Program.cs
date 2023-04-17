using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// this is a middleware that is used to log the information about the request and response.
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();


// Add RecurtingDbContext using SQL Server Provider
builder.Services.AddDbContext<RecurtingDbContext>(options =>
{
    // use UseQueryTrackingBehavior extension method to disable change tracking
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    // use UseSqlServer extension method to add SQL Server provider, which we call the UseSqlServer method on the DbContextOptionsBuilder object and pass the connection string to it.
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDb"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


