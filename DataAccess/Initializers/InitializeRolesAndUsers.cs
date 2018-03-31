using AusTest.Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AusTest.DataAccess.Initializers
{
    public class InitializeRolesAndUsers
    {
        public static async Task Init(AusTestDbContext context, RoleManager<AusTestRole> roleManager, UserManager<AusTestUser> userManager) {
            AusTestRole userRole = null;

            /* create role(s) */

            if (!await roleManager.RoleExistsAsync("User"))
            {
                userRole = new AusTestRole();
                userRole.Name = "User";
                await roleManager.CreateAsync(userRole);
            }
            else
                userRole = await roleManager.FindByNameAsync("User");

            /* create user(s) */

            var adminUser = new AusTestUser
            {
                UserName = "user@domain.com",
                Email = "user@domain.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            await userManager.CreateAsync(adminUser, "AusTest1");
            await userManager.AddToRoleAsync(adminUser, "User");
        }
    }
}
