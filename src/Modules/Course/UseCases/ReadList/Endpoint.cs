
using System.Linq.Expressions;
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<Course> Repository { get; init; }

    public override void Configure()
    {
        Get("courses");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            Expression<Func<Course, bool>> query = course => course.InstituteId.Equals(req.InstituteId);
            var courses = await Repository.GetPagedAsync(req.Page, req.PageSize, query);
            await SendOkAsync(Map.FromEntity(courses), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}