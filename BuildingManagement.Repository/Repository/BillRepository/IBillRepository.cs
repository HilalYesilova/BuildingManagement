using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.BillRepository
{
    public interface IBillRepository
    {
        Task AddBillToBuildingAsync(Bill bill);
    }
}
