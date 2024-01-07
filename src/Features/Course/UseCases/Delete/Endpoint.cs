
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.Delete;

public class Endpoint : Endpoint<Request, Response>
{
    public IGenericRepository<Course> Repository { get; init; }

    public override void Configure()
    {
        Delete("courses/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetCouse = await Repository.FindAsync(course => course.Id.Equals(req.Id));
            if (targetCouse is null)
            {
                await SendNotFoundAsync();
                return;
            }
            targetCouse.Active = false;
            await Repository.Update(targetCouse);

            await SendOkAsync(new(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}