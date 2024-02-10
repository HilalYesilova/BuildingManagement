using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.User
{
    public class UserRegularPayment
    {
        public int UserId { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
    }
}
