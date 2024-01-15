


using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.room.UseCases.ReadList;

public class Mapper : Mapper<Request, PagedResult<Response>, PagedResult<Room>>
{

    public override PagedResult<Response> FromEntity(PagedResult<Room> e) => new()
    {
        RowCount = e.RowCount,
        PageCount = e.PageCount,
        PageSize = e.PageSize,
        CurrentPage = e.CurrentPage,
        Results = e.Results.Select((Room e) =>
            new Response()
            {
                Id = e.Id,
                Name = e.Name,
                Capacity = e.Capacity,
                Block = e.Block,
                RoomTypeId = e.RoomTypeId,
                RoomType = e.Type.Name,
            }
        ).ToList()
    };
}