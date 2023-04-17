using Infrastructure.Repositories;
using MVCLearning.UserRepo;

var builder = WebApplication.CreateBuilder(args);

// when we need to change the repository, we just need to change the UserRepository
builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();
builder.Services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
builder.Services.AddScoped<IOperationScoped, Operation>();

// use of OperationService
builder.Services.AddTransient<OperationService, OperationService>();


// to use DepartmentRepository from Infrastructure
builder.Services.AddSingleton<DepartmentRepository, DepartmentRepository>();


// Add services to the container.
builder.Services.AddControllersWithViews();

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

