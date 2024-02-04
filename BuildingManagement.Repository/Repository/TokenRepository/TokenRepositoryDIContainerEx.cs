using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.TokenRepository.Repository;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.Service.TokenServices
{
    public static class TokenRepositoryDIContainerEx
    {
        public static void AddTokenRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<ITokenRepository,TokenRepository>();
        }
    }
}
