
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.ReadOne;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Teacher> Repository { get; init; }

    public override void Configure()
    {
        Get("teachers/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetTeacher = await Repository.FindAsync(teacher => teacher.Id.Equals(req.Id));

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