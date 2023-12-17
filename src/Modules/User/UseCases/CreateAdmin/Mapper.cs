
using System.Globalization;

namespace timeasy_api.src.Modules.user.UseCases.Create;

public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request r) => new()
    {
        FullName = r.FullName,
        Email = r.Email,
        Password = r.Password,
    };

    public Institute ToInstituteEntity(Request r) => new()
    {
        Name = r.InstituteName,
        OpenHour = r.OpenHour.ToTimeSpan(),
        CloseHour = r.CloseHour.ToTimeSpan(),
        Monday = r.Monday,
        Tuesday = r.Tuesday,
        Wednesday = r.Wednesday,
        Thursday = r.Thursday,
        Friday = r.Friday,
        Saturday = r.Saturday,
    };

    public Response FromEntityWithInstitute(User e, Institute i) => new()
    {
        Id = e.Id,
        FullName = e.FullName,
        Email = e.Email,
        InstituteId = e.InstituteId,
        InstituteName = i.Name,
        OpenHour = i.OpenHour,
        CloseHour = i.CloseHour,
        Monday = i.Monday,
        Tuesday = i.Tuesday,
        Wednesday = i.Wednesday,
        Thursday = i.Thursday,
        Friday = i.Friday,
        Saturday = i.Saturday,
    };
}