using System.Security.Claims;
using timeasy_api.src.modules.user.Repository;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Guid GetInstituteIdByCurrentUser(ClaimsPrincipal user);
        Guid GetUserIdByCurrentUser(ClaimsPrincipal user);
    }
}
