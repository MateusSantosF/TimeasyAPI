
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Course> Repository { get; init; }

    public override void Configure()
    {
        Post("courses");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var newCourse = Map.ToEntity(req);
            var result = await Repository.CreateAsync(newCourse);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}