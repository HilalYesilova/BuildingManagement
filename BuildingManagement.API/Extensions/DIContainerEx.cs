using BuildingManagement.Repository;
using BuildingManagement.Repository.DIContainer;
using BuildingManagement.Service.DIContainer;

namespace BuildingManagement.API.Extensions;
public static class DIContainerEx
{
    public static void AddDIContainer(this IServiceCollection services)
    {
        services.AddTokenServiceDIContainer();
        services.AddTokenRepositoryDIContainer();

        services.AddBillServiceDIContainer();
        services.AddBillRepositoryDIContainer();

        services.AddDebtServiceDIContainer();
        services.AddDebtRepositoryDIContainer();

        services.AddDuesServiceDIContainer();
        services.AddDuesRepositoryDIContainer();

        services.AddPaymentServiceDIContainer();
        services.AddPaymentRepositoryDIContainer();

        services.AddUserServiceDIContainer();
        services.AddUserRepositoryDIContainer();

        services.AddApartmentServiceDIContainer();
        services.AddApartmentRepositoryDIContainer();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
