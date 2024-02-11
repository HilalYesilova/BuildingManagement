using BuildingManagement.Entity.Entities;
using BuildingManagement.Entity.Enums;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.User;
using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.PaymentRepository;
using BuildingManagement.Repository.Repository.UserRepository;
using BuildingManagement.Service.Helpers;
using BuildingManagement.Service.Extensions;

namespace BuildingManagement.Service.Service.UserServices
{
    public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPaymentRepository paymentRepository) : IUserService
    {
        public async Task<ResponseDto<UserDebtAndDuesInfoResponse>> GetUserDebtAndDuesInfoAsync(int id)
        {
            var user = await userRepository.GetUserAsync(id);
            if (user == null) return ResponseDto<UserDebtAndDuesInfoResponse>.Fail("Kullanıcı Bulunamadı");

            var bills = await userRepository.GetBillsInfoAsync(id);
            var dues = await userRepository.GetDuesInfoAsync(id);
            var debtsAndDues = new DebtAndDuesInfo();
            var debtsInfos = new List<DebtInfo>();
            var duesInfos = new List<DuesInfo>();
            try
            {
                foreach (var bill in bills)
                {
                    debtsInfos.Add(new DebtInfo
                    {
                        Month = bill.Month,
                        Year = bill.Year,
                        Debt = (bill.GasAmount + bill.WaterAmount + bill.ElectricityAmount).ToString(),
                        IsPaid = bill.IsPaid,
                    });
                }
                foreach (var due in dues)
                {
                    duesInfos.Add(new DuesInfo
                    {
                        Month = due.Month,
                        Year = due.Year,
                        Dues = due.Amount.ToString(),
                        IsPaid = due.IsPaid,
                    });
                }
                debtsAndDues.duesInfos = duesInfos;
                debtsAndDues.debtInfos = debtsInfos;

                var returnList = new UserDebtAndDuesInfoResponse();
                returnList.UserId = user.Id;
                returnList.UserName = user.UserName;
                returnList.debtAndDuesInfos = debtsAndDues;
                return ResponseDto<UserDebtAndDuesInfoResponse>.Success(returnList);
            }
            catch (Exception e)
            {
                return ResponseDto<UserDebtAndDuesInfoResponse>.Fail(e.Message);
            }
        }

        public async Task<ResponseDto<string>> MakePaymentAsync(UserPaymentRequestDto paymentRequest)
        {
            var currentDate = DateTime.Now;
            var lastDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));

            var apartment = await userRepository.GetUserApartmentAsync(paymentRequest.ApartmentId);
            if (apartment == null) return ResponseDto<string>.Fail("Tanımlı Daire Bulunamadı!");
            if (paymentRequest.IsDues)
            {
                var dues = await userRepository.GetDuesInfoAsync((int)apartment.UserId);
                var duesInfo = dues.Where(d => d.Month == paymentRequest.Month.MonthFormat()).FirstOrDefault();
                if (duesInfo == null || duesInfo.IsPaid) return ResponseDto<string>.Fail("Bu Aidat Zaten ödenmiş!");

                duesInfo.IsPaid = true;
                await userRepository.UpdateDuesAsync(duesInfo);
                unitOfWork.Commit();

                #region For overdue payments, an additional 10% must be collected.
                decimal amountToPay = PaymentHelper.CalculateAmountToPay(duesInfo.Amount, currentDate, lastDayOfMonth);
                #endregion

                #region Check for regular payment
                var pastYear = currentDate.AddYears(-1);
                var pastPayments = await paymentRepository.GetAllPaymentDataByApartmentId(apartment.Id, pastYear.Year.ToString());
                bool isRegularPayment = PaymentHelper.CheckRegularPayment(pastPayments);
                if (isRegularPayment)
                {
                    amountToPay *= 0.9m; // %10 indirim yap
                }
                #endregion
                var paymentType = new PaymentType
                {
                    Method = PaymentTypes.Dues
                };
                var payment = new Payment
                {
                    PaymentMethod = paymentRequest.Method,
                    PaymentDate = currentDate,
                    Amount = duesInfo.Amount,
                    Month = duesInfo.Month.ToString(),
                    Year = duesInfo.Year.ToString(),
                    UserId = (int)duesInfo.Apartment.UserId,
                    ApartmentId = duesInfo.Apartment.Id,
                    PaymentType = paymentType,
                    Dues = duesInfo
                };
                await paymentRepository.AddPaymentAsync(payment);
                unitOfWork.Commit();
                return ResponseDto<string>.Success("Ödeme Başarı İle gerçekleşmiştir!");
            }
            if (paymentRequest.IsBill)
            {
                var bills = await userRepository.GetBillsInfoAsync((int)apartment.UserId);
                var billInfo = bills.Where(b => b.Month == paymentRequest.Month.Month.ToString()).FirstOrDefault();
                if (billInfo == null || billInfo.IsPaid) return ResponseDto<string>.Fail("Bu Aidat Zaten ödenmiş!");

                billInfo.IsPaid = true;
                await userRepository.UpdateBillAsync(billInfo);
                unitOfWork.Commit();

                #region For overdue payments, an additional 10% must be collected.
                var totalAmount = (billInfo.GasAmount + billInfo.ElectricityAmount + billInfo.WaterAmount);
                decimal amountToPay = PaymentHelper.CalculateAmountToPay(totalAmount, currentDate, lastDayOfMonth);
                #endregion

                var paymentType = new PaymentType
                {
                    Method = PaymentTypes.Dues
                };
                var payment = new Payment
                {
                    PaymentMethod = paymentRequest.Method,
                    PaymentDate = currentDate,
                    Amount = totalAmount,
                    Month = billInfo.Month.ToString(),
                    Year = billInfo.Year.ToString(),
                    UserId = (int)billInfo.Apartment.UserId,
                    ApartmentId = billInfo.Apartment.Id,
                    PaymentType = paymentType,
                    ApartmentBill = billInfo
                };
                await paymentRepository.AddPaymentAsync(payment);
                unitOfWork.Commit();
                return ResponseDto<string>.Success("Ödeme Başarı İle gerçekleşmiştir!");
            }
            return ResponseDto<string>.Fail("Lütfen Ödeme Yapmak İstediğiniz Borcu Seçiniz!");
        }

        public async Task<ResponseDto<List<UserRegularPayment>>> UserRegularPayment()
        {
            try
            {
                var userList = await userRepository.GetAllUsers();
                var pastYear = DateTime.Now.AddYears(-1);
                var regularUsers = new List<UserRegularPayment>();
                foreach (var user in userList)
                {
                    var pastPayments = await paymentRepository.GetAllPaymentDataByApartmentId(user.Apartment!.Id, pastYear.Year.ToString());
                    bool isRegularPayment = PaymentHelper.CheckRegularPayment(pastPayments);
                    if (isRegularPayment)
                    {
                        var regularUser = new UserRegularPayment
                        {
                            UserId = user.Id,
                            Name = user.Name,
                            Surname = user.Surname
                        };
                        regularUsers.Add(regularUser);
                    }
                }

                return ResponseDto<List<UserRegularPayment>>.Success(regularUsers);
            }
            catch (Exception e)
            {
                return ResponseDto<List<UserRegularPayment>>.Fail("Yıllık düzenli ödeyen kullanıcı bulunamadı!");
            }

        }
    }
}
