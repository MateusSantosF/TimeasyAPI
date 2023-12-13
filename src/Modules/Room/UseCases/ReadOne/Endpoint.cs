
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.room.UseCases.ReadOne;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Room> Repository { get; init; }

    public override void Configure()
    {
        Get("rooms/{id}");
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

            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}