namespace timeasy_api.src.Modules.teacher.UseCases.Update;

public class Mapper : Mapper<Request, Response, Teacher>
{
    public override Teacher ToEntity(Request r) => new()
    {
        Id = r.Id,
        FullName = r.FullName,
        Email = r.Email,
        Registration = r.Registration.ToUpper(),
    };

    public override Response FromEntity(Teacher e) => new()
    {
        Id = e.Id,
        FullName = e.FullName,
        Email = e.Email,
        Registration = e.Registration,
        InstituteId = e.InstituteId,
    };
}