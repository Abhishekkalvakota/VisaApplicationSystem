using Microsoft.EntityFrameworkCore;
using VisaApplicationSysWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VisaDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VisaAppConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ApplyVisa}/{action=Student}/{id?}"

    );

app.MapControllerRoute(
      name: "api",
      pattern: "api/{controller}/{action}/{id?}"

      );

app.MapControllers();


app.Run();
