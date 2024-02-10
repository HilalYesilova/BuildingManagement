using BuildingManagement.Repository.Repository.PaymentRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class PaymentRepositoryDIContainerEx
    {
        public static void AddPaymentRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<PaymentRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
