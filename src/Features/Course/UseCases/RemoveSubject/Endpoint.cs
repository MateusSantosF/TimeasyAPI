
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.RemoveSubject;

public class Endpoint : Endpoint<Request, Response>
{

    public IGenericRepository<CourseSubject> repository { get; init; }

    public override void Configure()
    {
        Delete("courses/subjects/{Id}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetCourseSubject = await repository.FindAsync(cs => cs.Id.Equals(req.Id));

            if (targetCourseSubject is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            repository.Delete(targetCourseSubject);

            await SendOkAsync(new(), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}