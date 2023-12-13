
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.subject.UseCases.Update;

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

            var newSubject = Map.ToEntity(req);
            var result = await Repository.CreateAsync(newSubject);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}