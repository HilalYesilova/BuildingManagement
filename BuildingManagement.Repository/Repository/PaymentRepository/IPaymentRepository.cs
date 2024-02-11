using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Repository.Repository.PaymentRepository;
public interface IPaymentRepository
{
    Task<IEnumerable<Apartment>> GetApartmentsPaymentsAsync();

    Task AddPaymentAsync(Payment payment);

    Task<IEnumerable<Payment>> GetAllPaymentDataByApartmentId(int ApartmentId, string lastYear);

}
