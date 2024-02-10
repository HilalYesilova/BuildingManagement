using BuildingManagement.Service.Service.TokenServices.Interfaces;
using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.DIContainer
{
    public static class TokenServiceDIContainerEx
    {
        public static void AddTokenServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IdentityService>();
            services.AddScoped<TokenService>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
