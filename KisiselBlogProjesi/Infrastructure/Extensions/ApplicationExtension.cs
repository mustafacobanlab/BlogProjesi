using Microsoft.AspNetCore.Identity;

namespace KisiselBlogProjesi.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static async Task ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            using var scope = app.ApplicationServices.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser
                {
                    Email = "info@mustafacoban.com.tr",
                    PhoneNumber = "5061112233",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                    throw new Exception("Admin user could not been created.");

                var roleResult = await userManager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role definition for admin.");
            }
        }
    }
}
