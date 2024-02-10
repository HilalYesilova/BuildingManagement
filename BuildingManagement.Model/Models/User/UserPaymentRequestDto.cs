using BuildingManagement.Entity.Entities;
using BuildingManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.User
{
    public class UserPaymentRequestDto
    {
        public int ApartmentId { get; set; }
        public DateTime Month { get; set; }
        public bool IsDues { get; set; } = false;
        public bool IsElectricityBill { get; set; } = false;
        public bool IsWaterBill { get; set; } = false;
        public bool IsGasBill { get; set; } = false;
        public PaymentMethod Method { get; set; }
    }
}
