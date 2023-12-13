using Microsoft.Extensions.Options;

using System.Security.Claims;
using System.Text;
using TimeasyAPI.src.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using timeasy_api.src.modules.user.Repository;
using timeasy_api.src.Core;

namespace TimeasyAPI.src.Services
{
    public class TokenService : ITokenService
    {

        private readonly AppSettings _settings;

        private readonly string INSTITUTE_ID_KEY = "InstituteId";
        private readonly string USER_ID_KEY = "UserId";

        public TokenService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public Guid GetInstituteIdByCurrentUser(ClaimsPrincipal user)
        {
            var instituteId = user.Claims.FirstOrDefault(c => c.Type == INSTITUTE_ID_KEY) ?? throw new Exception("Invalid user");
            return Guid.Parse(instituteId.Value);
        }

        public Guid GetUserIdByCurrentUser(ClaimsPrincipal user)
        {
            var userId = user.Claims.FirstOrDefault(c => c.Type == USER_ID_KEY) ?? throw new Exception("Invalid user");

            return Guid.Parse(userId.Value);
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.TokenConfiguration.SecretJwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FullName.ToString()),
                    new Claim(ClaimTypes.Role, user.AcessLevel.ToString()),
                    new Claim(USER_ID_KEY, user.Id.ToString()),
                    new Claim(INSTITUTE_ID_KEY, user.InstituteId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.TokenConfiguration.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
