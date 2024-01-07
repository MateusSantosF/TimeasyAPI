
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.room.UseCases.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Room> Repository { get; init; }

    public override void Configure()
    {
        Post("rooms");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var newRoom = Map.ToEntity(req);
            var result = await Repository.CreateAsync(newRoom);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}