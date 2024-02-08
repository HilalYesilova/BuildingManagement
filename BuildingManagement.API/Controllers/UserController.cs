using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {

        [HttpGet("{userId}/bills-and-dues")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserBillsAndDues(Guid userId)
        {
            // Kullanıcının daire bilgisini al
            var user = await _context.Users
                .Include(u => u.Apartment)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            // Kullanıcının bağlı olduğu dairenin fatura ve aidatlarını al
            var billsAndDues = await _context.ApartmentBills
                .Include(ab => ab.Apartment)
                .Where(ab => ab.Apartment.Id == user.ApartmentId)
                .Select(ab => new
                {
                    ab.Id,
                    ab.Month,
                    ab.ElectricityAmount,
                    ab.WaterAmount,
                    ab.GasAmount,
                    ab.IsPaid,
                    Type = "Bill"
                })
                .Union(_context.Dues
                    .Where(d => d.ApartmentId == user.ApartmentId)
                    .Select(d => new
                    {
                        d.Id,
                        Month = new DateTime(int.Parse(d.Year), int.Parse(d.Month), 1),
                        Amount = d.Amount,
                        IsPaid = d.IsPaid,
                        Type = "Dues"
                    }))
                .ToListAsync();

            return Ok(billsAndDues);
        }





        [HttpPost("pay")]
        public async Task<ActionResult> MakePayment(int paymentId)
        {
            // Ödemeyi al
            var payment = await _context.Payments
                .Include(p => p.Apartment)
                .Include(p => p.PaymentType)
                .FirstOrDefaultAsync(p => p.Id == paymentId);

            if (payment == null)
            {
                return NotFound();
            }

            // Ödemenin zaten yapılmış olup olmadığını kontrol et
            if (payment.PaymentType.Name == "Dues" && payment.Dues.IsPaid)
            {
                return BadRequest("Bu aidat zaten ödenmiş.");
            }
            else if (payment.PaymentType.Name == "Bill" && payment.ApartmentBills.IsPaid)
            {
                return BadRequest("Bu fatura zaten ödenmiş.");
            }

            // Ödeme yapıldığında IsPaid değerini true olarak ayarla
            if (payment.PaymentType.Name == "Dues")
            {
                payment.Dues.IsPaid = true;
            }
            else if (payment.PaymentType.Name == "Bill")
            {
                payment.ApartmentBills.IsPaid = true;
            }

            // Ödeme tarihini kaydet
            payment.PaymentDate = DateTime.Now;

            // Ödemeyi kaydet
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();

            return Ok("Ödeme başarıyla yapıldı.");
        }












        [HttpGet("{userId}/bills-and-dues")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserBillsAndDues(Guid userId, int year, int month)
        {
            // Kullanıcının daire bilgisini al
            var user = await _context.Users
                .Include(u => u.Apartment)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            // Kullanıcının bağlı olduğu dairenin fatura ve aidatlarını al
            var billsAndDues = await _context.ApartmentBills
                .Include(ab => ab.Apartment)
                .Where(ab => ab.Apartment.Id == user.ApartmentId &&
                             ab.Month.Year == year && ab.Month.Month == month)
                .Select(ab => new
                {
                    ab.Id,
                    ab.Month,
                    ab.ElectricityAmount,
                    ab.WaterAmount,
                    ab.GasAmount,
                    ab.IsPaid,
                    Type = "Bill"
                })
                .Union(_context.Dues
                    .Where(d => d.ApartmentId == user.ApartmentId &&
                                d.Year == year && d.Month == month)
                    .Select(d => new
                    {
                        d.Id,
                        Month = new DateTime(int.Parse(d.Year), int.Parse(d.Month), 1),
                        Amount = d.Amount,
                        IsPaid = d.IsPaid,
                        Type = "Dues"
                    }))
                .ToListAsync();

            return Ok(billsAndDues);
        }
    }
}
