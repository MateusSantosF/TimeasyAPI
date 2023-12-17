
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.room.UseCases.Delete;

public class Endpoint : Endpoint<Request, Response>
{
    public IGenericRepository<Room> Repository { get; init; }

    public override void Configure()
    {
        Delete("rooms/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var result = await Repository.FindAsync(room => room.Id.Equals(req.Id));

            if (result is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            result.Active = false;

            await Repository.Update(result);
            await SendOkAsync(new(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}