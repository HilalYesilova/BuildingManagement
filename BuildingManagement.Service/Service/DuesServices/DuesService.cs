using BuildingManagement.Entity.Entities;
using BuildingManagement.Model.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.DuesServices
{
    public class DuesService : IDuesService
    {
        public async Task AssignDuesAsync(AssignDuesRequestDto model)
        {
            //var apartments = await _context.Apartments
            //    .Where(a => model.ApartmentIds.Contains(a.Id))
            //    .ToListAsync();

            //var dues = new List<Dues>();

            //foreach (var apartment in apartments)
            //{
            //    // Create a new dues object
            //    var due = new Dues
            //    {
            //        Amount = model.Amount,
            //        IsPaid = false,
            //        ApartmentId = apartment.Id
            //    };

            //    var payment = new Payment
            //    {
            //        PaymentMethod = model.PaymentMethod,
            //        PaymentDate = DateTime.Now,
            //        PaymentCategory = "Association",
            //        Amount = model.Amount,
            //        Month = model.Month,
            //        Year = model.Year,
            //        ApartmentId = apartment.Id,
            //        UserId = apartment.UserId,
            //        PaymentTypeId = model.PaymentTypeId
            //    };

            //    await _context.Payments.AddAsync(payment);

            //    await _context.SaveChangesAsync();

            //    due.PaymentId = payment.Id;

            //    dues.Add(due);
            //}

            //await _context.Dues.AddRangeAsync(dues);

            //await _context.SaveChangesAsync();
        }
    }
}
