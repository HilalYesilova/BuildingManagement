using BuildingManagement.Entity.Entities;

namespace BuildingManagement.Model.Models.Payments.ApartmentPaymentDto
{
    public class ApartmentPaymentDto
    {
        public int ApartmentId { get; set; }
        public List<Payment>? Payment { get; set; }
    }
}
