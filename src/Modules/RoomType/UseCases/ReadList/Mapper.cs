

using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadList;

public class Mapper : Mapper<Request, PagedResult<Response>, PagedResult<RoomType>>
{
    public override PagedResult<Response> FromEntity(PagedResult<RoomType> e) => new()
    {
        CurrentPage = e.CurrentPage,
        Results = e.Results.Select((RoomType e) =>
            new Response()
            {
                Id = e.Id,
                Name = e.Name,
                IsComputerLab = e.IsComputerLab,
                OperationalSystem = e.OperationalSystem?.GetDescription()
            }
        ).ToList()
    };
}