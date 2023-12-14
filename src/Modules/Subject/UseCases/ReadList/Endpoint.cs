
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
            var targetSubject = await Repository.GetAllAsync(req.Page, req.PageSize);

            await SendOkAsync(Map.FromEntity(targetSubject), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}