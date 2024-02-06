using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.BillRepository
{
    public class BillRepository(AppDbContext _context) : IBillRepository
    {
        public Task AddBillToBuildingAsync(Bill bill)
        {
           var billValue = _context.Bills.Add(bill);
           return Task.CompletedTask;
        }
    }
}
