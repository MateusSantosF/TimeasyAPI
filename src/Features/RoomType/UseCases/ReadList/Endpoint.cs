
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<RoomType> Repository { get; init; }

    public override void Configure()
    {
        Get("roomtypes");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            Expression<Func<RoomType, bool>> query = roomType => roomType.InstituteId.Equals(req.InstituteId)
            && (string.IsNullOrWhiteSpace(req.Query) || roomType.Name.Contains(req.Query));

            var targetRoomType = await Repository.GetPagedAsync(req.Page, req.PageSize, query);

            await SendOkAsync(Map.FromEntity(targetRoomType), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}