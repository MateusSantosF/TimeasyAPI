namespace timeasy_api.src.Modules.course.UseCases.ReadOne;

public class Mapper : Mapper<Request, Response, Course>
{

    public override Response FromEntity(Course e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        PeriodAmount = e.PeriodAmount,
        Period = e.Period.GetDescription(),
        Turn = e.Turn.GetDescription(),
        InstituteId = e.InstituteId,
        Subjects = e.CourseSubject.Select(s =>
        {
            return new SubjectResponse()
            {
                Id = s.Id,
                SubjectId = s.SubjectId,
                Name = s.Subject.Name,
                Acronym = s.Subject.Acronym,
                Complexity = s.Subject.Complexity.GetDescription(),
                RoomTypeId = s.Subject.RoomTypeId,
                WeeklyClassCount = s.WeeklyClassCount,
                Period = s.Period,
            };
        }).ToList()
    };
}