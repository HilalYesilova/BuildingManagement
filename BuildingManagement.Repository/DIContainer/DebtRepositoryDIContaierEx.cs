using BuildingManagement.Repository.Repository.DebtRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class DebtRepositoryDIContaierEx
    {
        public static void AddDebtRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<DebtRepository>();
            services.AddScoped<IDebtRepository, DebtRepository>();
        }
    }
}
