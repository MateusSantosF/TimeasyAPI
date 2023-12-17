
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.Update;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<Teacher> Repository { get; init; }

    public override void Configure()
    {
        Put("teachers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetTeacher = await Repository.FindAsync(teacher => teacher.Id.Equals(req.Id));

            if (targetTeacher is null)
            {
                await SendNotFoundAsync();
                return;
            }

            var updatedData = Map.ToEntity(req);
            updatedData.InstituteId = targetTeacher.InstituteId;
            var result = await Repository.Update(updatedData);
            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}