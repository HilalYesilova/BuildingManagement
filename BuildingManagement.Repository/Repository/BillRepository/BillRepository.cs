﻿using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.BillRepository;

public class BillRepository(AppDbContext context) : IBillRepository
{
    private readonly AppDbContext _context = context;

    public Task AddBillToApartmentAsync(ApartmentBill bill)
    {
        _context.Add(bill);
        return Task.CompletedTask;
    }

    public Task AddBillToBuildingAsync(Bill bill)
    {
        var billValue = _context.Bills.Add(bill);
        return Task.CompletedTask;
    }
}
