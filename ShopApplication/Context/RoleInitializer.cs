using Microsoft.AspNetCore.Identity;
using ShopApplication.Models;
using System.Data;

namespace CollectionsProject.Context
{
    public static class RoleInitializer
    {
        private const string ADMIN = "admin";
        private const string USER = "user";

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "123456";
            string adminName = "adminUser";
            if (await roleManager.FindByNameAsync(ADMIN) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN));
            }
            if (await roleManager.FindByNameAsync(USER) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(USER));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new() { Email = adminEmail, UserName = adminName};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, ADMIN);
                }
            }
        }
    }
}
