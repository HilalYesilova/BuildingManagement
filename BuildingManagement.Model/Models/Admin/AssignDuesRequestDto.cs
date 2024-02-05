using BuildingManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.Admin
{
    public class AssignDuesRequestDto
    {
        [Required]
        public List<int> ApartmentIds { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }


    }
}
