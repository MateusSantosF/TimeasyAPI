
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.room.UseCases.Update;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Room> Repository { get; init; }

    public override void Configure()
    {
        Put("rooms");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var newRoom = Map.ToEntity(req);
            var result = await Repository.Update(newRoom);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}