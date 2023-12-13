using System.Security.Claims;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Guid GetInstituteIdByCurrentUser(ClaimsPrincipal user);
        Guid GetUserIdByCurrentUser(ClaimsPrincipal user);
    }
}
