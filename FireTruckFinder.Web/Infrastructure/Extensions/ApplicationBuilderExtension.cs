namespace FireTruckFinder.Web.Infrastructure.Extensions
{
    using FireTruckFinder.Data;
    using FireTruckFinder.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<FireTruckFinderDbContext>().Database.Migrate();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var roles = new[]
                        {
                            WebConstants.AdministratorRole,
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@mysite.com";
                        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = WebConstants.AdministratorRole,
                                Birtdate = DateTime.UtcNow,          
                            };

                            await userManager.CreateAsync(adminUser, "admin12");
                            await userManager.AddToRoleAsync(adminUser, WebConstants.AdministratorRole);
                        }
                    }).Wait();
            }

            return app;
        }
    }
}
