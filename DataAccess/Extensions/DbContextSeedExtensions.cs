using AusTest.DataAccess.Initializers;
using AusTest.Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AusTest.DataAccess.Extensions
{
    public static class DbContextExtensions
    {
        public static void Initialize(this AusTestDbContext context, RoleManager<AusTestRole> roleManager, UserManager<AusTestUser> userManager, bool enforceCreate = false)
        {
            if (enforceCreate)
                context.Database.EnsureDeleted();

            if (context.Database.EnsureCreated())
            {
                Seed(context, roleManager, userManager);
            }
        }

        private static void Seed(AusTestDbContext context, RoleManager<AusTestRole> roleManager, UserManager<AusTestUser> userManager)
        {
            InitializeRolesAndUsers.Init(context, roleManager, userManager).Wait();
        }
    }
}
