using codigonaveia.academias.Domain.Entities.Account;
using codigonaveia.academias.Domain.Intefaces;
using codigonaveia.academias.Infra.Data.Contexto;
using codigonaveia.academias.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<DataContexto>(options =>
{
    options.UseSqlServer(strConnection);
});

builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
    //options.Password.RequireDigit = false;
    //options.Password.RequireUppercase = false;
    //options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequiredLength = 6;
   

}).AddEntityFrameworkStores<DataContexto>()
  .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(3));

builder.Services.AddScoped<IAlunosRepository, AlunosRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
