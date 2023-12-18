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
    pattern: "{controller=User}/{action=Login}/{id?}"

    );

app.MapControllerRoute(
      name: "api",
      pattern: "api/{controller}/{action}/{id?}"

      );


app.MapControllerRoute(
    name: "profileRoute",
    pattern: "User/Profile/{visatypeId}/{applicantId}",
    defaults: new { controller = "User", action = "Profile" }
);

app.MapControllerRoute(
    name: "visaStatusRoute",
    pattern: "User/GetVisaStus/{applicantId}",
    defaults: new { controller = "User", action = "GetVisaStus" }
);


app.MapControllers();


app.Run();
