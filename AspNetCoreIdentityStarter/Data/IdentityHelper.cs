using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityStarter.Data
{
    internal static class IdentityHelper
    {
        internal static readonly string Admin = "Admin";
        internal static readonly string Student = "Stu";

        internal static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityResult roleResult;

            foreach(string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        internal static void SetIdentityConfigOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }
    }
}
