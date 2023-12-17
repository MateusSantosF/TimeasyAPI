
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.subject.UseCases.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Subject> Repository { get; init; }

    public override void Configure()
    {
        Post("subjects");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
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