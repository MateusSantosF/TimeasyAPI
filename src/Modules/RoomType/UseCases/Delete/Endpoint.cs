
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.roomtype.UseCases.Delete;

public class Endpoint : Endpoint<Request, Response>
{
    public IGenericRepository<RoomType> Repository { get; init; }

    public override void Configure()
    {
        Delete("roomtypes/{Id}");
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

            targetRoomType.Active = false;

            var result = await Repository.Update(targetRoomType);
            await SendOkAsync(new(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}