using BuildingManagement.Repository.Repository.ApartmentRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class ApartmentRepositoryDIContainer
    {
        public static void AddApartmentRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<ApartmentRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
        }
    }
}
