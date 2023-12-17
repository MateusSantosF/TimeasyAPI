
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.ReadOne;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Course> Repository { get; init; }

    public override void Configure()
    {
        Get("courses/{Id}");
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
            await SendOkAsync(Map.FromEntity(targetCouse), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}