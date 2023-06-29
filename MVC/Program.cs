using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions() { Args = args, WebRootPath = "" });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option => 
    {
        option.ExpireTimeSpan = new TimeSpan(0, 1, 0);
        option.LoginPath = "/home/privacy";
        option.LogoutPath = "/home/error";
    });

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("people.json");



var app = builder.Build();

Debug.WriteLine(app.Configuration["students:name"]);

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
