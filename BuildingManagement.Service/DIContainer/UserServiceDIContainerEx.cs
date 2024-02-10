using BuildingManagement.Service.Service.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Service.DIContainer
{
    public static class UserServiceDIContainerEx
    {
        public static void AddUserServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
