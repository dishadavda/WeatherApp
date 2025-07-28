using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Weartherapp.Components;
using Weartherapp.Data;
using Weartherapp.Services;
using Weartherapp.Services.Implement;
using Weartherapp.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(o => o.DetailedErrors = true);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.Configure<SendGridSettings>(
    builder.Configuration.GetSection("SendGrid"));
builder.Services.Configure<OpenWeatherSettings>(
    builder.Configuration.GetSection("OpenWeatherMap"));
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "WeartherAppAuthCookie"; // Name of your authentication cookie
        options.LoginPath = "/login"; // Path to your login page
        options.LogoutPath = "/logout"; // Path to your logout action (if you have one)
        options.AccessDeniedPath = "/access-denied"; // Path for access denied page
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
        options.SlidingExpiration = true; // Renew cookie on activity
    });

builder.Services.AddScoped<EmailSender>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 43))));
builder.Services.AddHttpClient<ICityWeatherService, WeatherService>();
builder.Services.AddBlazoredLocalStorage();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
