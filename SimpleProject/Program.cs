using Microsoft.EntityFrameworkCore;
using SimpleProject.Data;
using SimpleProject.Services.Implementations;
using SimpleProject.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Connect to database
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:dbcontext"]));

// Create one instance from the project lifecycle
//builder.Services.AddSingleton<IProductService, ProductService>();

// Create one instance for the same request
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

// Create one instance for each request even if the same request
//builder.Services.AddTransient<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

// is equal
//app.MapDefaultControllerRoute();

app.Run();
