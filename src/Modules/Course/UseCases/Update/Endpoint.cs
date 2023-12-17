
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.Update;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Course> Repository { get; init; }

    public override void Configure()
    {
        Put("courses/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetCourse = await Repository.FindAsync(course => course.Id.Equals(req.Id));
            if (targetCourse is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            var updatedCourse = Map.ToEntity(req);
            updatedCourse.InstituteId = targetCourse.InstituteId;

            var result = await Repository.Update(updatedCourse);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}