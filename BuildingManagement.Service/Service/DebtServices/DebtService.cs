using BuildingManagement.Model.Models.Debt;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository.Repository.DebtRepository;

namespace BuildingManagement.Service.Service.DebtServices;
public class DebtService(IDebtRepository debtRepository) : IDebtService
{
    public async Task<ResponseDto<IEnumerable<DebtResponseDto>>> GetApartmentsDebts()
    {
        var apartments = await debtRepository.GetAllDebtsAsync();
        var debts = new List<DebtResponseDto>();
        if (apartments == null) return ResponseDto<IEnumerable<DebtResponseDto>>.Fail("Apartmanlar bulunamadı");

        foreach (var apartment in apartments.Where(s => s.OccupancyStatus).ToList())
        {
            var apartmentDebts = apartments
                                            .Where(a => a.Id == apartment.Id)
                                            .SelectMany(s => s.ApartmentBills)
                                            .Where(b => !b.IsPaid);

            decimal monthlyDebt = apartmentDebts != null ? apartmentDebts.Sum(b => b.ElectricityAmount + b.WaterAmount + b.GasAmount) : 0;

            var yearlyDebts = apartmentDebts
                                        .GroupBy(b => b.Year)
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
