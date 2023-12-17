


namespace timeasy_api.src.Modules.teacher.UseCases.ReadOne;
public class Request
{
    public Guid Id { get; set; }
}

public class Response
{
    public Guid Id { get; set; }
    public string Registration { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public Guid InstituteId { get; set; }
}