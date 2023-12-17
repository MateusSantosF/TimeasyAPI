
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.AddWorkSchedule;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<WorkSchedule> Repository { get; init; }
    public IGenericRepository<Teacher> TeacherRepository { get; init; }

    public override void Configure()
    {
        Post("teachers/{id}/workschedule");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetTeacherWorkSchedule = await Repository.GetAllAsync(WorkSchedule => WorkSchedule.TeacherId.Equals(req.Id));

            if (targetTeacherWorkSchedule is null)
            {
                await SendNotFoundAsync();
                return;
            }
            var newWorkTime = Map.ToEntity(req);
            ValidateWorkSchedule(newWorkTime, targetTeacherWorkSchedule);

            var result = await Repository.CreateAsync(newWorkTime);
            await SendOkAsync(Map.FromEntity(newWorkTime), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }

    private void ValidateWorkSchedule(WorkSchedule newWorkSchedule, List<WorkSchedule> currentTeacherWorkschedule)
    {

        if (newWorkSchedule.End < newWorkSchedule.Start) ThrowError(e => e.End, "O Horário de fim não pode ser menor que o começo.");

        foreach (var existingSchedule in currentTeacherWorkschedule)
        {
            if ((newWorkSchedule.Start >= existingSchedule.Start && newWorkSchedule.Start < existingSchedule.End) ||
                (newWorkSchedule.End > existingSchedule.Start && newWorkSchedule.End <= existingSchedule.End))
            {
                ThrowError(e => e.Start, "O novo horário entra em conflito com um horário existente.");
            }
        }

    }
}