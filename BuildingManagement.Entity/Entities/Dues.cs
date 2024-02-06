using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Month { get; set; }
        public string Year { get; set; }

        // Bir Dues, bir Apartment'a aittir (One-to-Many)
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public Payment Payment { get; set; }
    }

}
