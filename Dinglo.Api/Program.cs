using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using Dinglo.Domain.Authorizations;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Repositories;

namespace Dinglo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserIdentity>>();
                var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<UserIdentity>>();
                var options = scope.ServiceProvider.GetRequiredService<IOptions<AppJwtSettings>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                var authUser = new AuthUser(userManager, signInManager, options, roleManager, userRepository);
                authUser.CreateDefaultUserAdmin("sysadmin@dinglo.com.br", "sysadmin@dinglo.com.br", "p@ssw0rd").Wait();
            }
            
            webHost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
