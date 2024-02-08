using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.User;
using BuildingManagement.Repository.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.UserServices
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<ResponseDto<IEnumerable<UserDebtAndDuesInfoResponse>>> GetUserDebtAndDuesInfo(Guid id)
        {
            var userInfo = new List<UserDebtAndDuesInfoResponse>();
            var user = await userRepository.GetUserAsync(id);
            if (user == null) return ResponseDto<IEnumerable<UserDebtAndDuesInfoResponse>>.Fail("Kullanıcı Bulunamadı");


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
    }
}
