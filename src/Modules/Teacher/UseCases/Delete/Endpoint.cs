
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.Delete;

public class Endpoint : Endpoint<Request, Response>
{
    public IGenericRepository<Teacher> Repository { get; init; }

    public override void Configure()
    {
        Delete("teachers/{Id}");
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
            targetTeacher.Active = false;
            await Repository.Update(targetTeacher);

            await SendOkAsync(new(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}