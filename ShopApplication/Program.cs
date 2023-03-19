using CollectionsProject.Context;
using EntityFrameworkCore.UseRowNumberForPaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Context;
using ShopApplication.Models;
using ShopApplication.Repository.Implementation;
using ShopApplication.Repository.Interfaces;
using ShopApplication.Services.Implementation;
using ShopApplication.Services.Interfaces;
using System.Globalization;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.AddControllersWithViews()
            .AddDataAnnotationsLocalization()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder);

        var connection = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { "en", "ru" };
            options.SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
        });

        builder.Services.AddDbContext<ApplicationContext>
            (opt => opt.UseSqlServer(connection, builder => builder.UseRowNumberForPaging()));

        builder.Services.AddIdentity<User, IdentityRole>(opts =>
        {
            opts.Password.RequiredLength = 1;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireDigit = false;
            opts.User.RequireUniqueEmail = true;

        }).AddEntityFrameworkStores<ApplicationContext>()
        .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

        AddDependencies(builder);
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var userManager = services.GetRequiredService<UserManager<User>>();
                var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await RoleInitializer.InitializeAsync(userManager, rolesManager);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/Error/PageNotFound");

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        var supportedCultures = new[] { "en", "ru" };
        // 5. 
        // Culture from the HttpRequest
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static void AddDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IPaginationService,PaginationService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IUserRepository,UserRepository>();
    }
}