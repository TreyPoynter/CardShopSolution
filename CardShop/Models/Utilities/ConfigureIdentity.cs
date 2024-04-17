using CardShop.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace CardShop.Models.Utilities
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(
            IServiceProvider provider, ConfigurationManager configuration)
        {
            var roleManager = 
                provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager =
                provider.GetRequiredService<UserManager<User>>();

            string firstName = configuration["Admin:FirstName"]?.ToString() ?? "John";
            string lastName = configuration["Admin:LastName"]?.ToString() ?? "Doe";
            string email = configuration["Admin:Email"]?.ToString() ?? "johndoe@email.com";
            string password = configuration["Admin:Password"]?.ToString() ?? "Ses@me#4";
            string roleName = "Admin";

            if(await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            if(await userManager.FindByEmailAsync(email) == null)
            {
                User user = new User() 
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
