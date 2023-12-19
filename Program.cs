using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<Appuser, IdentityRole>().AddEntityFrameworkStores<Appdbcontext>();

builder.Services.AddDbContext<Appdbcontext>(

    options => { options.UseSqlServer("Server = .\\SQLEXPRESS; Database = TheBookStore; Integrated Security = SSPI; TrustServerCertificate = True; "); }
    );





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
