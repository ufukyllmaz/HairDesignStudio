using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HairDesginStudio.Data;
using HairDesginStudio.Models;
using HairDesginStudio.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

//builder.Services.AddDefaultIdentity<AdvanceUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<AdvanceUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false; // Rakam gereksinimini kaldırır
    options.Password.RequiredLength = 3; // Minimum şifre uzunluğunu 3 yapar
    options.Password.RequireNonAlphanumeric = false; // Alfasayısal olmayan karakter zorunluluğunu kaldırır
    options.Password.RequireUppercase = false; // Büyük harf zorunluluğunu kaldırır
    options.Password.RequireLowercase = false; // Küçük harf zorunluluğunu kaldırır

})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IHairStyleService, OpenAIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Reservations/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservations}/{action=Index}");
app.MapRazorPages();

app.Run();
