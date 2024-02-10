using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.TokenRepository.Repository;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class TokenRepositoryDIContainerEx
    {
        public static void AddTokenRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IdentityRepository>();       
            services.AddScoped<TokenRepository>();

            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
        }
    }
}
