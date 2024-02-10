using BuildingManagement.Repository.Repository.BillRepository;
using BuildingManagement.Service.Service.BillServices;
using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.DIContainer
{
    public static class BillServiceDIContainerEx
    {
        public static void AddBillServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<BillService>();
            services.AddScoped<IBillService, BillService>();
        }
    }
}
