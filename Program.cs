using MudBlazor.Services;
using MudBlazorWebApp5.Components;
using MudBlazorWebApp5.IService;
using MudBlazorWebApp5.Service;
using MudBlazorWebApp5.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Blazored.LocalStorage;
using MudBlazorWebApp5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("MyDb")
    );
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "auth_token";
//        options.LoginPath = "/";
//        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
//        options.AccessDeniedPath = "/";
//    });

builder.Services.AddMudServices();
builder.Services.AddScoped<IBookFloorService, BookFloorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
