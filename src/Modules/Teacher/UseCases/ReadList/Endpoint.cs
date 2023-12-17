
using System.Linq.Expressions;
using timeasy_api.src.Core.Pagination;
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.ReadList;

public class Endpoint : Endpoint<Request, PagedResult<Response>, Mapper>
{
    public IGenericRepository<Teacher> Repository { get; init; }

    public override void Configure()
    {
        Get("teachers");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            Expression<Func<Teacher, bool>> query = teacher => teacher.InstituteId.Equals(req.InstituteId);

            var targetTeacher = await Repository.GetPagedAsync(req.Page, req.PageSize, query);

            if (targetTeacher is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(Map.FromEntity(targetTeacher), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}
