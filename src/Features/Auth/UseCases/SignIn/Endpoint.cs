
using System.Security.Claims;
using FastEndpoints.Security;
using Microsoft.Extensions.Options;
using timeasy_api.src.Core;
using timeasy_api.src.Repository;
using TimeasyAPI.src.Services.Interfaces;

namespace timeasy_api.src.Modules.user.UseCases.signin;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<User> _userRepository { get; init; }
    public ITokenService _tokenService { get; init; }
    public IOptions<AppSettings> _settings { get; init; }

    public override void Configure()
    {
        Post("user/signin");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetUser = await _userRepository.FindAsync(user => user.Email.Equals(req.Email) && user.Password.Equals(req.Password));

            if (targetUser is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var acessToken = JWTBearer.CreateToken(
                signingKey: _settings.Value.TokenConfiguration.SecretJwtKey,
                expireAt: DateTime.UtcNow.AddDays(1),
                privileges: u =>
                {
                    u.Roles.Add(targetUser.AcessLevel.ToString());
                    u.Claims.Add(new(ClaimTypes.Name, targetUser.FullName));
                    u.Claims.Add(new(ClaimTypes.NameIdentifier, targetUser.Id.ToString()));
                    u.Claims.Add(new("InstituteId", targetUser.InstituteId.ToString()));
                });

            var mappedUser = Map.FromEntity(targetUser);
            mappedUser.AccessToken = acessToken;

            await SendOkAsync(mappedUser, ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}