using BuildingManagement.Model.Models.Payments.ApartmentPaymentDto;
using BuildingManagement.Model.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.PaymentServis
{
    public interface IPaymentService
    {
        Task<ResponseDto<IEnumerable<ApartmentPaymentDto>>> GetApartmentsPayments();
    }
}
