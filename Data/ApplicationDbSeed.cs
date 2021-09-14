using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotDefterim.Data
{
    public static class ApplicationDbSeed
    {
        public static async Task SeedRolesAndUsers(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            // admin rolü henüz yoksa oluştur
            // https://www.gencayyildiz.com/blog/cta-async-await-ikilisiyle-asenkron-islemler/

            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "admin" });
            }

            // admin rolünde bir kullanıcı yoksa admin rolüyle ekle (admin@example.com)

            if (!await userManager.Users.AnyAsync(x => x.Email == "admin@example.com"))
            {
                ApplicationUser adminUser = new ApplicationUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "P@ssword1");
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}
