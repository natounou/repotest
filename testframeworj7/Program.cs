using NuGet.Protocol.Core.Types;
using testframeworj7.Controllers;
using Microsoft.EntityFrameworkCore;
using testframeworj7.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting.Server;

var builder = WebApplication.CreateBuilder(args);
string _connectionstring = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EtablissementContext>(options => options.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));
builder.Services.AddDbContext<ReservationsContext>(options => options.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));
builder.Services.AddDbContext<TypesdeChambresContext>(options => options.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));
builder.Services.AddDbContext<TarifsContext>(options => options.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));
builder.Services.AddDbContext<ChambresContext>(options => options.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));
builder.Services.AddDbContext<ClientsContext>(options => options.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring)));
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    
    //services.AddScoped<DbContext, EtablissementContext>();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(" / Home/Error");
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

