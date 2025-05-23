using AspNetCore.Identity.Mongo.Model;
using BlazorApp1.Data;
using BlazorApp1.Enum;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp1.Helper
{
    public static class RoleProvider
    {
        public static void CreateDefaultRoles(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<MongoRole>>();

            string[] roles = { "Admin", "Student", "Teacher" };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    var result = roleManager.CreateAsync(new MongoRole(role)).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Failed to create role {role}");
                    }
                }
            }
        }
        //public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
        //{
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        //    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    foreach (var role in new[] { AppRoles.Student, AppRoles.Teacher, AppRoles.Admin })
        //    {
        //        if (!await roleManager.RoleExistsAsync(role))
        //            await roleManager.CreateAsync(new ApplicationRole(role));
        //    }

        //    // Optional: Seed admin user
        //    var admin = await userManager.FindByEmailAsync("admin@example.com");
        //    if (admin == null)
        //    {
        //        admin = new ApplicationUser { UserName = "admin", Email = "admin@example.com" };
        //        await userManager.CreateAsync(admin, "Admin@123");
        //        await userManager.AddToRoleAsync(admin, AppRoles.Admin);
        //    }
        //}


    }


}
