


using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.subject.UseCases.ReadList;

public class Mapper : Mapper<Request, PagedResult<Response>, PagedResult<Subject>>
{

    public override PagedResult<Response> FromEntity(PagedResult<Subject> e) => new()
    {
        CurrentPage = e.CurrentPage,
        Results = e.Results.Select((Subject e) =>
            new Response()
            {
                Id = e.Id,
                Acronym = e.Acronym,
                Name = e.Name,
                Complexity = e.Complexity.GetDescription(),
                RoomTypeId = e.RoomTypeId,
            }
        ).ToList()
    };
}