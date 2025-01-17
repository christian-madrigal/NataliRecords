
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NataliRecords.DB_Data;
using NataliRecords.Models;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IData, Data>();
builder.Services.AddSession();
builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddIdentity<Customer, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;

}).AddEntityFrameworkStores<ApplicationDbContext>();
static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
{
    string[] rolenames = { "Admin", "Customer" };
    foreach (var rolename in rolenames)
    {
        bool roleExists = await roleManager.RoleExistsAsync(rolename);
        if (!roleExists)
        {
            IdentityRole role = new IdentityRole();
            role.Name = rolename;
            IdentityResult result = await roleManager.CreateAsync(role);
        }
    }
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
