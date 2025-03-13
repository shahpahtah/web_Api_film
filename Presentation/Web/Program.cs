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
            options.AccessDeniedPath = "/Account/AccessDenied"; // ����, ���� �������������� ��� ������ � �������
            options.Cookie.Name = "YourAppCookie"; // ��� Cookie (����� ��� ������������)
            options.Cookie.HttpOnly = true; // Cookie �������� ������ ������� (������ �� XSS)
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // ����� ����� Cookie (��������, 60 �����)
            options.LoginPath = "/Account/Login"; // ���� � �������� �����
            options.LogoutPath = "/Account/Logout"; // ���� � �������� ������
            options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            options.SlidingExpiration = true; // ���������� ����� ����� Cookie ��� ������ �������

            //  �������������� ��������� (�����������)
            options.Cookie.IsEssential = true; // ��������� �� Cookie ����������� ��� ������ �����
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // ��������� HTTPS
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