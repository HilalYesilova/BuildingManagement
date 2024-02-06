using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.Admin
{
    public class AddBillRequestDto
    {
        public int BuildingId { get; set; }
        public DateTime Month { get; set; }
        public decimal ElectricityAmount { get; set; } 
        public decimal WaterAmount { get; set; }
        public decimal GasAmount { get; set; }
    }
}
