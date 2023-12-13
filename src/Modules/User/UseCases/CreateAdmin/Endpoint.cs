
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.user.UseCases.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<User> _userRepository { get; init; }
    public IGenericRepository<Institute> _repository { get; init; }

    public override void Configure()
    {
        Post("user/root");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var InstituteMapped = Map.ToInstituteEntity(req);
            var newInstitute = await _repository.CreateAsync(InstituteMapped);

            var newAdminUser = Map.ToEntity(req);
            newAdminUser.AcessLevel = AcessLevel.Root;
            newAdminUser.InstituteId = InstituteMapped.Id;

            var result = await _userRepository.CreateAsync(newAdminUser);
            await SendOkAsync(Map.FromEntityWithInstitute(newAdminUser, InstituteMapped), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}