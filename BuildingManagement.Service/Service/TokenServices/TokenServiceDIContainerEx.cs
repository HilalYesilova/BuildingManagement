using BuildingManagement.Service.Service.TokenServices.Interfaces;
using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.Service.TokenServices
{
    public static class TokenServiceDIContainerEx
    {
        public static void AddTokenServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService,IdentityService>();
            services.AddScoped<ITokenService,TokenService>();
        }
    }
}
