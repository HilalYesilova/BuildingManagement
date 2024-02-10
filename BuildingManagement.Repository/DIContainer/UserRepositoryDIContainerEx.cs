using BuildingManagement.Repository.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Repository.DIContainer
{
    public static class UserRepositoryDIContainerEx
    {
        public static void AddUserRepositoryDIContainer(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
