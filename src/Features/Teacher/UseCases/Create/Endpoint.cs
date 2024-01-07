
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Teacher> Repository { get; init; }

    public override void Configure()
    {
        Post("teachers");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var newTeacher = Map.ToEntity(req);
            var result = await Repository.CreateAsync(newTeacher);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}