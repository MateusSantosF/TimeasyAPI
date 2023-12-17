


namespace timeasy_api.src.Modules.teacher.UseCases.ReadOne;

public class Mapper : Mapper<Request, Response, Teacher>
{
    public override Response FromEntity(Teacher e) => new()
    {
        Id = e.Id,
        FullName = e.FullName,
        Email = e.Email,
        Registration = e.Registration,
        InstituteId = e.InstituteId,
    };
}