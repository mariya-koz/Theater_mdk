using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Theater_mdk.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor(); // авторизация
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Theater_mdk")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // куда перекидывать неавторизованных
        options.AccessDeniedPath = "/Account/AccessDenied"; // можно отдельно /AccessDenied
        options.Cookie.Name = "StudentLibraryCookie";
        options.ExpireTimeSpan = TimeSpan.FromHours(1); // Срок действия
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseHttpsRedirection();
app.UseRouting(); 

app.UseAuthentication();// порядок важен
app.UseAuthorization(); // внимание эта после UseAuthentication

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();


app.Run();
