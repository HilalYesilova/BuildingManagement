using BuildingManagement.Service.Service.PaymentServis;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.DIContainer
{
    public static class PaymentServiceDIContainerEx
    {
        public static void AddPaymentServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<PaymentService>();
            services.AddScoped<IPaymentService,PaymentService>();
        }
    }
}
