using BuildingManagement.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.Repository.Repository.DebtRepository;

public class DebtRepository(AppDbContext context) : IDebtRepository
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<Apartment>> GetAllDebtsAsync()
    {
        return await _context.Apartments.Where(a => a.OccupancyStatus).ToListAsync();
    }
    public async Task<IEnumerable<ApartmentBill>> GetAllBillsAsync(int apartmentId)
    {
        return await _context.ApartmentBills.Where(b=>b.ApartmentId== apartmentId).ToListAsync();
    }
}
