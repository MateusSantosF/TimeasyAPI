
using timeasy_api.src.Repository;

namespace timeasy_api.src.Modules.teacher.UseCases.UpdateWorkSchedule;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IGenericRepository<WorkSchedule> Repository { get; init; }
    public IGenericRepository<Teacher> TeacherRepository { get; init; }

    public override void Configure()
    {
        Put("teachers/{TeacherId}/workschedule/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        try
        {
            var targetTeacherWorkSchedule = await Repository.GetAllAsync(WorkSchedule => WorkSchedule.TeacherId.Equals(req.TeacherId));

            if (targetTeacherWorkSchedule is null)
            {
                await SendNotFoundAsync();
                return;
            }

            var updatedWorkTime = Map.ToEntity(req);
            ValidateWorkSchedule(updatedWorkTime, targetTeacherWorkSchedule);
            var result = await Repository.Update(updatedWorkTime);
            await SendOkAsync(Map.FromEntity(updatedWorkTime), ct);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }

    private void ValidateWorkSchedule(WorkSchedule updatedWorkSchedule, List<WorkSchedule> currentTeacherWorkschedule)
    {

        var targetScheduleIndex = currentTeacherWorkschedule.Find(schedule => schedule.Id.Equals(updatedWorkSchedule.Id));

        if (targetScheduleIndex is null)
        {
            ThrowError(r => r.Id, "Não foi encontrado um horário com o ID informado");
        }
        var sucessRemoved = currentTeacherWorkschedule.Remove(targetScheduleIndex);

        if (updatedWorkSchedule.End < updatedWorkSchedule.Start) ThrowError(e => e.End, "O Horário de fim não pode ser menor que o começo.");

        foreach (var existingSchedule in currentTeacherWorkschedule)
        {
            if ((updatedWorkSchedule.Start >= existingSchedule.Start && updatedWorkSchedule.Start <= existingSchedule.End) ||
                (updatedWorkSchedule.End > existingSchedule.Start && updatedWorkSchedule.End <= existingSchedule.End))
            {
                ThrowError(e => e.Start, "O novo horário entra em conflito com um horário existente.");
            }
        }

    }
}