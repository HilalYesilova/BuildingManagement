using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Entity.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public DateTime Month { get; set; } 
        public decimal ElectricityAmount { get; set; }
        public decimal WaterAmount { get; set; }
        public decimal GasAmount { get; set; }
    }
}
