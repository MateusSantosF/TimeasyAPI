
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.DeleteWorkSchedule;

public class Endpoint : Endpoint<Request, Response>
{
    public IGenericRepository<WorkSchedule> Repository { get; init; }

    public override void Configure()
    {
        Delete("teachers/workschedule/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            Repository.Delete(new WorkSchedule() { Id = req.Id });

            await SendOkAsync(new Response(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}