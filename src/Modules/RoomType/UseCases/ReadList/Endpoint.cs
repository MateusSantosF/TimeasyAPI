
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.modules.roomType;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<RoomType> Repository { get; init; }

    public override void Configure()
    {
        Get("roomtypes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetRoomType = await Repository.GetAllAsync(req.Page, req.PageSize);

            await SendOkAsync(Map.FromEntity(targetRoomType), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}