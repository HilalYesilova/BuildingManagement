using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.AdminRepository
{
    public interface IDuesRepository
    {
        Task<List<Apartment>> GetAllApartmentsAsync(List<Dues> dues);
        Task AddDuesToApartments(List<Dues> dues);
    }
}
