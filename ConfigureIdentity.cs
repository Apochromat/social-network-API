using Microsoft.AspNetCore.Identity;
using social_network_API.Models;
using social_network_API.Models.Enum;

namespace social_network_API; 

public static class ConfigureIdentity {
    public static async Task ConfigureIdentityAsync(this WebApplication app) {
        using var serviceScope = app.Services.CreateScope();
        var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
        var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
        var config = app.Configuration.GetSection("DefaultUsersConfig");

        // Try to create Administrator Role
        var adminRole = await roleManager.FindByNameAsync(ApplicationRoleNames.Administrator);
        if (adminRole == null) {
            var roleResult = await roleManager.CreateAsync(new Role {
                Name = ApplicationRoleNames.Administrator,
                Type = RoleType.Administrator
            });
            if (!roleResult.Succeeded) {
                throw new InvalidOperationException($"Unable to create {ApplicationRoleNames.Administrator} role.");
            }

            adminRole = await roleManager.FindByNameAsync(ApplicationRoleNames.Administrator);
        }

        // Try to create Moderator Role
        var teacherRole = await roleManager.FindByNameAsync(ApplicationRoleNames.Moderator);
        if (teacherRole == null) {
            var roleResult = await roleManager.CreateAsync(new Role {
                Name = ApplicationRoleNames.Moderator,
                Type = RoleType.Moderator
            });
            if (!roleResult.Succeeded) {
                throw new InvalidOperationException($"Unable to create {ApplicationRoleNames.Moderator} role.");
            }
        }

        // Try to create User Role
        var studentRole = await roleManager.FindByNameAsync(ApplicationRoleNames.User);
        if (studentRole == null) {
            var roleResult = await roleManager.CreateAsync(new Role {
                Name = ApplicationRoleNames.User,
                Type = RoleType.User
            });
            if (!roleResult.Succeeded) {
                throw new InvalidOperationException($"Unable to create {ApplicationRoleNames.User} role.");
            }
        }

        // Try to create Administrator user
        var adminUser = await userManager.FindByEmailAsync(config["AdminEmail"]);
        if (adminUser == null) {
            var userResult = await userManager.CreateAsync(new User {
                FullName = config["AdminFullName"],
                UserName = config["AdminUserName"],
                Email = config["AdminEmail"],
            }, config["AdminPassword"]);
            if (!userResult.Succeeded) {
                throw new InvalidOperationException($"Unable to create {config["AdminUserName"]} user");
            }
            
            adminUser = await userManager.FindByNameAsync(config["AdminUserName"]);
        }

        if (!await userManager.IsInRoleAsync(adminUser, adminRole.Name)) {
            await userManager.AddToRoleAsync(adminUser, adminRole.Name);
        }
    }
}