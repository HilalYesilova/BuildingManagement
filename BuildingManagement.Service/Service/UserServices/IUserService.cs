using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.User;

namespace BuildingManagement.Service.Service.UserServices;
public interface IUserService
{
    Task<ResponseDto<UserDebtAndDuesInfoResponse>> GetUserDebtAndDuesInfoAsync(int id);
    Task<ResponseDto<string>> MakePaymentAsync(UserPaymentRequestDto paymentRequest);
    Task<ResponseDto<List<UserRegularPayment>>> UserRegularPayment();
}
