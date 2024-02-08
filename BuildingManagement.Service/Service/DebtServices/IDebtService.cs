using BuildingManagement.Model.Models.Debt;
using BuildingManagement.Model.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.DebtServices
{
    public interface IDebtService
    {
        Task<ResponseDto<IEnumerable<DebtResponseDto>>> GetApartmentsDebts();
    }
}
