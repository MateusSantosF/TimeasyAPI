


using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.course.UseCases.ReadList;

public class Mapper : Mapper<Request, PagedResult<Response>, PagedResult<Course>>
{
    public override PagedResult<Response> FromEntity(PagedResult<Course> e) => new()
    {
        CurrentPage = e.CurrentPage,
        Results = e.Results.Select((Course course) =>
        {
            return new Response()
            {
                Id = course.Id,
                Name = course.Name,
                PeriodAmount = course.PeriodAmount,
                Period = course.Period.GetDescription(),
                Turn = course.Turn.GetDescription(),
                InstituteId = course.InstituteId
            };
        }).ToList()
    };
}