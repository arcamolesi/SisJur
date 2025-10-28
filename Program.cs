using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SisJur.Models;
using SisJur.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("conexao")));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityDataContext>();


builder.Services.AddDbContext<IdentityDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexao")));


builder.Services.AddTransient<IEmailSender, MockEmailSender>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Configura??es de senha (exemplo)
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;

    // Configura??es de Lockout
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;

    // Configura??es de SignIn
    options.SignIn.RequireConfirmedAccount = false; // Mude para true se quiser confirma??o de email
})
.AddEntityFrameworkStores<IdentityDataContext>() // Aponta para o DbContext do Identity
.AddDefaultTokenProviders(); // Para tokens de reset de senha, etc.

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // <-- PRIMEIRO: Quem � voc�?
app.UseAuthorization();  // <-- SEGUNDO: O que voc� pode fazer?

app.MapStaticAssets();
app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
