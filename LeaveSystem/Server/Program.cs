using LeaveSystem.BusinessLayer.Mappings;
using LeaveSystem.BusinessLayer.Services;
using LeaveSystem.DataLayer.Repositories;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Interfaces.Repositories;
using LeaveSystem.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SystemDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(builder.Environment.IsDevelopment() ? "develop" : "master"));
});
builder.Services.AddScoped<DbContext>(provider => provider.GetService<SystemDbContext>());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IFunctionRepository, FunctionRepository>();
builder.Services.AddScoped<IFunctionService, FunctionService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
