using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dinglo.Domain.Authorizations;
using Dinglo.Domain.Repositories;
using Dinglo.Infra.Repositories;
using Dinglo.Domain.Handlers;

namespace Dinglo.Api.Helper
{
    public static class DependencyRegister
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Transient Entities Repositories
            services.AddTransient<ICustAccountRepository, CustAccountRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Transient Entities Handlers
            services.AddTransient<CustAccountHandler, CustAccountHandler>();
            services.AddTransient<AppUserHandler, AppUserHandler>();
            
            // Transient Security
            services.AddTransient<IAuthUser, AuthUser>();
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}