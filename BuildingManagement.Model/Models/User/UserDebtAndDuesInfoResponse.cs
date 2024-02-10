using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.User
{
    public class UserDebtAndDuesInfoResponse
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DebtAndDuesInfo? debtAndDuesInfos { get; set; }
    }

    public class DebtAndDuesInfo
    {
        public IEnumerable<DebtInfo>? debtInfos { get; set; }
        public IEnumerable<DuesInfo>? duesInfos { get; set; }
    }

    public class DebtInfo
    {
        public string Month { get; set; } = default!;
        public string Year { get; set; } = default!;
        public string? Debt { get; set; }
        public bool IsPaid { get; set; }
    }
    public class DuesInfo
    {
        public string Month { get; set; } = default!;
        public string Year { get; set; } = default!;
        public string? Dues { get; set; }
        public bool IsPaid { get; set; }
    }
}
