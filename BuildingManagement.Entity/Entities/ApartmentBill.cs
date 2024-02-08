using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Entity.Entities
{
    public class ApartmentBill
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; } // Hangi daireye ait olduğunu belirtmek için ApartmentId kullanılır
        public Apartment Apartment { get; set; } // Bu faturanın ait olduğu daireyi temsil eden nesne

        public DateTime Month { get; set; } // Fatura ayını belirtmek için
        public decimal ElectricityAmount { get; set; } // Elektrik faturası tutarı
        public decimal WaterAmount { get; set; } // Su faturası tutarı
        public decimal GasAmount { get; set; } // Doğalgaz faturası tutarı
        public bool IsPaid { get; set; }= false;
    }
}
