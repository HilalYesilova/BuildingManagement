using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.User
{
    public class UserDebtAndDuesInfoResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = default!;
        public IEnumerable<DebtAndDuesInfo>? debtAndDuesInfos { get; set; }
    }

    public class DebtAndDuesInfo
    {
        public DateTime Month { get; set; }
        public string? Dues { get; set; }
        public string? Debt { get; set; }
    }
}
