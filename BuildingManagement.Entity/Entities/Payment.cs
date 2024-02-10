using BuildingManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Entity.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Month { get; set; } = default!;
        public string Year { get; set; } = default!;
        public int UserId { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; } = default!;

        // Bir Payment, bir Apartment'a aittir (One-to-Many)
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public int? DuesId { get; set; }
        public Dues? Dues { get; set; }
        public int? ApartmentBillId { get; set; }
        public ApartmentBill? ApartmentBill { get; set; }
    }
}
