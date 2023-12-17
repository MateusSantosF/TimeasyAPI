
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.course.UseCases.UpdateSubject;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public ICourseRepository CourseRepository { get; init; }

    public IGenericRepository<CourseSubject> repository { get; init; }

    public override void Configure()
    {
        Put("courses/{CourseId}/subjects");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetCouse = await CourseRepository.GetAllWithSubjectsAsync(req.CourseId);

            if (targetCouse is null)
            {
                await SendNotFoundAsync();
                return;
            }

            if (targetCouse.PeriodAmount < req.Period)
            {
                ThrowError(r => r.Period, "O período da disciplina deve respeitar o número de períodos do Curso.");
            }

            var targetSubject = targetCouse.CourseSubject.Find(s => s.SubjectId.Equals(req.SubjectId));

            if (targetSubject is null)
            {
                ThrowError(r => r.SubjectId, "Essa disciplina ainda não foi adicionada a este curso.");
            }

            var couseSubject = Map.ToEntity(req);

            var result = await repository.Update(couseSubject);

            await SendOkAsync(Map.FromEntity(result), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}