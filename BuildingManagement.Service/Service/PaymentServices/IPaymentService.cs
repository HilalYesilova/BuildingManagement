using BuildingManagement.Model.Models.Payments.ApartmentPaymentDto;
using BuildingManagement.Model.Models.Shared;

namespace BuildingManagement.Service.Service.PaymentServis;
public interface IPaymentService
{
    Task<ResponseDto<IEnumerable<ApartmentPaymentDto>>> GetApartmentsPayments();
}
