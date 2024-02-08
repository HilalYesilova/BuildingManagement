using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid id);
        Task<Apartment> GetApartmentByUserId(Guid id);
        Task<IEnumerable<ApartmentBill?>> GetBillsInfo(Guid id);
        Task<IEnumerable<Dues?>> GetDuesInfo(Guid id);
    }
}
