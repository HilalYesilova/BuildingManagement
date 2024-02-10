using BuildingManagement.Service.Service.DuesServices;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.DIContainer
{
    public static class DuesServiceDIContainerEx
    {
        public static void AddDuesServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<DuesService>();
            services.AddScoped<IDuesService, DuesService>();
        }
    }
}
