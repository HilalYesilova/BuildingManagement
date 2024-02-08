using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.DebtRepository
{
    public interface IDebtRepository
    {
        Task<IEnumerable<Apartment>> GetAllDebtsAsync();
    }
}
