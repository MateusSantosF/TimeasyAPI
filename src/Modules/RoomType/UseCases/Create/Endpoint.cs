
using timeasy_api.src.modules.roomType;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.roomtype.UseCases.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<RoomType> Repository { get; init; }

    public override void Configure()
    {
        Post("roomtypes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var newRoomType = Map.ToEntity(req);
            var result = await Repository.CreateAsync(newRoomType);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}