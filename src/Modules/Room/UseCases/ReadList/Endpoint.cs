
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.room.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<Room> Repository { get; init; }

    public override void Configure()
    {
        Get("rooms");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var result = await Repository.GetAllAsync(req.Page, req.PageSize);

            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}