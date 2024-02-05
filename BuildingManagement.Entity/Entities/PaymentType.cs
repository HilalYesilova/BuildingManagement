using BuildingManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Entity.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public PaymentMethod Method { get; set; }
    }
}
