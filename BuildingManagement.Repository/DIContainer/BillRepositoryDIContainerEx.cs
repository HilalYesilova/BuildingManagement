using BuildingManagement.Repository.Repository.BillRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class BillRepositoryDIContainerEx
    {
        public static void AddBillRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<BillRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
        }
    }
}
