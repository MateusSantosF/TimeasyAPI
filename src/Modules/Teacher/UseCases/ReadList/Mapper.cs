


using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.teacher.UseCases.ReadList;

public class Mapper : Mapper<Request, PagedResult<Response>, PagedResult<Teacher>>
{
    public override PagedResult<Response> FromEntity(PagedResult<Teacher> e) => new()
    {
        CurrentPage = e.CurrentPage,
        Results = e.Results.Select((Teacher e) =>
            new Response()
            {
                Id = e.Id,
                FullName = e.FullName,
                Email = e.Email,
                Registration = e.Registration,
                InstituteId = e.InstituteId,
            }
        ).ToList()
    };
}