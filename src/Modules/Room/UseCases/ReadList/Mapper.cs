


using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.room.UseCases.ReadList;

public class Mapper : Mapper<Request, PagedResult<Response>, PagedResult<Room>>
{

    public override PagedResult<Response> FromEntity(PagedResult<Room> e) => new()
    {
        CurrentPage = e.CurrentPage,
        Results = e.Results.Select((Room e) =>
            new Response()
            {
                Id = e.Id,
                Name = e.Name,
                Capacity = e.Capacity,
                RoomTypeId = e.RoomTypeId,
                Block = e.Block
            }
        ).ToList()
    };
}