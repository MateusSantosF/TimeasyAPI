
using System.Linq.Expressions;
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.subject.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<Subject> Repository { get; init; }

    public override void Configure()
    {
        Get("subjects");

    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            Expression<Func<Subject, bool>> query = course => course.InstituteId.Equals(req.InstituteId);

            var targetSubject = await Repository.GetPagedAsync(req.Page, req.PageSize, query);

            await SendOkAsync(Map.FromEntity(targetSubject), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}