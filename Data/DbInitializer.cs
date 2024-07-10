using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                {
                    context.Database.EnsureCreated();
                    if (context.Users.Any())
                    {
                        return;
                    }
                    var user = new ApplicationUser
                    {
                        UserName = "test@gmail.com",
                        Email = "test@gmail.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user, "test@1234");
                    var admin = new ApplicationUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(admin, "admin@123");

                }
            }
        }
    }
}

