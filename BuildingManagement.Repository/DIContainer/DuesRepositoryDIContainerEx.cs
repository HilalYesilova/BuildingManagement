using BuildingManagement.Repository.Repository.AdminRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class DuesRepositoryDIContainerEx
    {
        public static void AddDuesRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<DuesRepository>();
            services.AddScoped<IDuesRepository, DuesRepository>();
        }
    }
}
