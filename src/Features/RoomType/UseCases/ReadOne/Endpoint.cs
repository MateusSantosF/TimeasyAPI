
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadOne;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<RoomType> Repository { get; init; }

    public override void Configure()
    {
        Get("roomtypes/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetRoomType = await Repository.FindAsync(rt => rt.Id.Equals(req.Id));
            if (targetRoomType is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(Map.FromEntity(targetRoomType), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}