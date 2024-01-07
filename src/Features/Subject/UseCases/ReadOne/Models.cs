

namespace timeasy_api.src.Modules.subject.UseCases.ReadOne;
public class Request
{
    public Guid Id { get; set; }
}


public class Response
{
    public Guid Id { get; set; }
    public string Acronym { get; set; }
    public string Name { get; set; }
    public string Complexity { get; set; }
    public Guid RoomTypeId { get; set; }
}