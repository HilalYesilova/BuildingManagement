using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Entity.Entities
{
    public class Dues
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; } = default!;
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }

}
