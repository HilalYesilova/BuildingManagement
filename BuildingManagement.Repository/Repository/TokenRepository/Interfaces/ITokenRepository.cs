using System.Security.Claims;
using BuildingManagement.Entity;

namespace BuildingManagement.Service.Service.TokenServices.Interfaces
{
    public interface ITokenRepository
    {
        Task<User?> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IList<Claim>> GetClaimsAsync(User user);
        Task<IList<string>> GetRolesAsync(User user);
    }
}
