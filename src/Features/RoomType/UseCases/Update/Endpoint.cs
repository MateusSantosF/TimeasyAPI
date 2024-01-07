
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.roomtype.UseCases.Update;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<RoomType> Repository { get; init; }

    public override void Configure()
    {
        Put("roomtypes");
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

            var roomType = Map.ToEntity(req);
            roomType.InstituteId = targetRoomType.InstituteId;
            var result = await Repository.Update(roomType);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}