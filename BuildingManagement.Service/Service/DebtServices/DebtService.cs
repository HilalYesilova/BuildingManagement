using BuildingManagement.Entity.Entities;
using BuildingManagement.Model.Models.Debt;
using BuildingManagement.Model.Models.Payments.ApartmentPaymentDto;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository.Repository.DebtRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.DebtServices
{
    public class DebtService(IDebtRepository debtRepository) : IDebtService
    {
        public async Task<ResponseDto<IEnumerable<DebtResponseDto>>> GetApartmentsDebts()
        {
            var apartments = debtRepository.GetAllDebtsAsync();
            var debts = new List<DebtResponseDto>();
            if (apartments == null) return ResponseDto<IEnumerable<DebtResponseDto>>.Fail("Apartmanlar bulunamadı");

            foreach (var apartment in apartments.Result.Where(s => s.OccupancyStatus).ToList())
            {
                var apartmentDebts = apartments.Result
                                                .Where(a => a.Id == apartment.Id)
                                                .SelectMany(s => s.ApartmentBills)
                                                .Where(b => !b.IsPaid);

                decimal monthlyDebt = apartmentDebts.Sum(b => b.ElectricityAmount + b.WaterAmount + b.GasAmount);

                var yearlyDebts = apartmentDebts
                                            .GroupBy(b => b.Month.Year)
                                            .Select(group => new
                                            {
                                                Year = group.Key,
                                                TotalDebt = group.Sum(b => b.ElectricityAmount + b.WaterAmount + b.GasAmount)
                                            });

                var debt = new DebtResponseDto
                {
                    ApartmentId = apartment.Id,
                    MonthlyDebt = monthlyDebt.ToString(),
                    AnnualDebt = yearlyDebts.ToString(),
                };
                debts.Add(debt);
            }
            return ResponseDto<IEnumerable<DebtResponseDto>>.Success(debts);
        }
    }
}
