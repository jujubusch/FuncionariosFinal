using Microsoft.EntityFrameworkCore;
using FuncionariosFinal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Ana Júlia Busch
    (options => options.UseSqlServer("Data Source=SP-1491020\\SQLSENAI;Initial Catalog = FuncionariosFinal;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Kauan
    (options => options.UseSqlServer("Data Source=SP-1491006\\SQLSENAI;Initial Catalog = FuncionariosFinal;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Pedro Lucas
    (options => options.UseSqlServer("Data Source=SP-1491032\\SQLSENAI;Initial Catalog = FuncionariosFinal;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Cauã
    (options => options.UseSqlServer("Data Source=SP-1491012\\SQLSENAI;Initial Catalog = FuncionariosFinal;Integrated Security = True;TrustServerCertificate = True"));*/

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
