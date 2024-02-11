using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.Token
{
    public class UserTokenCreateRequestDto
    {
        public string TcNo { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
