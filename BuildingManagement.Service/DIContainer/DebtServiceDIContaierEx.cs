using BuildingManagement.Repository.Repository.DebtRepository;
using BuildingManagement.Service.Service.DebtServices;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.DIContainer
{
    public static class DebtServiceDIContaierEx
    {
        public static void AddDebtServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<DebtService>();
            services.AddScoped<IDebtService, DebtService>();
        }
    }
}
