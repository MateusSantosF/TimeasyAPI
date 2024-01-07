

namespace timeasy_api.src.Modules.course.UseCases.ReadOne;
public class Request
{
    public Guid Id { get; set; }

}
public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int PeriodAmount { get; set; }
    public string Turn { get; set; }
    public string Period { get; set; }
    public Guid InstituteId { get; set; }
    public List<SubjectResponse> Subjects { get; set; }
}

public class SubjectResponse
{
    public Guid Id { get; set; }
    public Guid SubjectId { get; set; }
    public string Acronym { get; set; }
    public string Name { get; set; }
    public string Complexity { get; set; }
    public Guid RoomTypeId { get; set; }
    public int Period { get; set; }
    public int WeeklyClassCount { get; set; }
}