using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Entity.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string BlockInfo { get; set; }
        public bool OccupancyStatus { get; set; }
        public string ApartmentType { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string OwnerOrTenant { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Dues> Dues { get; set; }
    }
}
