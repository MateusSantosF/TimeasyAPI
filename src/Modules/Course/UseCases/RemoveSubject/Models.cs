

namespace timeasy_api.src.Modules.course.UseCases.RemoveSubject;
public class Request
{
    public Guid Id { get; set; }

}


public class Response
{
    public string Message { get; set; } = "Disciplina removida com sucesso!";

}