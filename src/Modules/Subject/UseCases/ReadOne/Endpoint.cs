
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.subject.UseCases.ReadOne;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Subject> Repository { get; init; }

    public override void Configure()
    {
        Put("subjects");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetSubject = await Repository.FindAsync(rt => rt.Id.Equals(req.Id));
            if (targetSubject is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendOkAsync(Map.FromEntity(targetSubject), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}