using BuildingManagement.Service.Service.ApartmentServices;
using BuildingManagement.Service.Service.BillServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.DIContainer
{
    public static class ApartmentServiceDIContainer
    {
        public static void AddApartmentServiceDIContainer(this IServiceCollection services)
        {
            services.AddScoped<ApartmentService>();
            services.AddScoped<IApartmentService, ApartmentService>();
        }
    }
}
