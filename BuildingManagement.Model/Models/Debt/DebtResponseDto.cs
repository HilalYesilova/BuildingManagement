using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Model.Models.Debt
{
    public class DebtResponseDto
    {
        public int ApartmentId { get; set; }
        public string? MonthlyDebt {  get; set; }
        public string? AnnualDebt {  get; set; }

    }
}
