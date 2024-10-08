using FluentAssertions;
using FluentAssertions.Common;
using MacFood.Context;
using MacFood.Models;
using MacFood.Repositories;
using MacFood.Repositories.Interfaces;
using MacFood.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", politic =>
    {
        politic.RequireRole("Admin");
    });
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => PurchaseCart.GetCart(sp));

builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

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

using (var scope = app.Services.CreateScope())
{
    var seedUserRoleInitial = scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
    seedUserRoleInitial.SeedRoles();
    seedUserRoleInitial.SeedUsers();
}

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "filterCategory",
    pattern: "Food/{action}/{category?}",
    defaults: new { Controller = "Food", Action = "List" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
