

namespace timeasy_api.src.Modules.course.UseCases.Delete;
public class Request
{
    public Guid Id { get; set; }

}
public class Response
{
    public string Message { get; set; } = "Curso removido com sucesso";

}