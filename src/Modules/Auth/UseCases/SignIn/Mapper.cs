

namespace timeasy_api.src.Modules.user.UseCases.signin;

public class Mapper : Mapper<Request, Response, User>
{
    public override Response FromEntity(User e) => new()
    {
        Id = e.Id,
        FullName = e.FullName,
        Email = e.Email,
        InstituteId = e.InstituteId,
    };
}