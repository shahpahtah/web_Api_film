using Application;
using Data;
using Film;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
public  class Program
{
    private static  void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddIdentity<UserDb, IdentityRole<Guid>>(options =>
        {
        }).AddEntityFrameworkStores<FilmContext>().AddDefaultTokenProviders();
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.AccessDeniedPath = "/Account/AccessDenied"; // Путь, куда перенаправлять при отказе в доступе
            options.Cookie.Name = "YourAppCookie"; // Имя Cookie (важно для уникальности)
            options.Cookie.HttpOnly = true; // Cookie доступен только серверу (защита от XSS)
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Время жизни Cookie (например, 60 минут)
            options.LoginPath = "/Account/Login"; // Путь к странице входа
            options.LogoutPath = "/Account/Logout"; // Путь к странице выхода
            options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            options.SlidingExpiration = true; // Продлевать время жизни Cookie при каждом запросе

            //  Дополнительные параметры (опционально)
            options.Cookie.IsEssential = true; // Считается ли Cookie необходимым для работы сайта
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Требовать HTTPS
        });
        builder.Services.AddDbContext<FilmContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Films")));
        builder.Services.AddAutoMapper(typeof(MapperProfile));

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
    }
}