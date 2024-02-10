using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.ApartmentRepository
{
    public interface IApartmentRepository
    {
        Task AddApartmentToBuildingAsync(Apartment apartment);
        Task<Building> GetBuildingInfo();
        Task AddUserToApartmentAsync(int apartmentId, User user);
    }
}
