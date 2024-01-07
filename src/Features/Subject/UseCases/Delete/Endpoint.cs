
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.subject.UseCases.Delete;

public class Endpoint : Endpoint<Request, Response>
{
    public IGenericRepository<Subject> Repository { get; init; }

    public override void Configure()
    {
        Delete("subjects/{Id}");
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
            targetSubject.Active = false;
            await Repository.Update(targetSubject);
            await SendOkAsync(new(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}