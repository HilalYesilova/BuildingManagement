using BuildingManagement.Model.Models.Debt;
using BuildingManagement.Model.Models.Shared;

namespace BuildingManagement.Service.Service.DebtServices;
public interface IDebtService
{
    Task<ResponseDto<IEnumerable<DebtResponseDto>>> GetApartmentsDebts();
}
