
using System.Linq.Expressions;
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.room.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<Room> Repository { get; init; }

    public override void Configure()
    {
        Get("rooms");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            Expression<Func<Room, bool>> query = course => course.InstituteId.Equals(req.InstituteId);
            var result = await Repository.GetPagedAsync(req.Page, req.PageSize, query);

            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}