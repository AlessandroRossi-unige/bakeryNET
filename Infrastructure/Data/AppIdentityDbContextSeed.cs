using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var userLuana = new AppUser()
                {
                    Email = "luana@bakerynet.com",
                    UserName = "luana@bakerynet.com",
                    DisplayName = "Luana Alderete",
                    FirstName = "Luana",
                    LastName = "Alderete"
                };
                
                var userMaria = new AppUser()
                {
                    Email = "maria@bakerynet.com",
                    UserName = "maria@bakerynet.com",
                    DisplayName = "Maria Vergata",
                    FirstName = "Maria",
                    LastName = "Vergata"
                };

                await userManager.CreateAsync(userLuana, "Pa$$w0rdL");
                await userManager.CreateAsync(userMaria, "Pa$$w0rdM");
            }
        }
    }
}