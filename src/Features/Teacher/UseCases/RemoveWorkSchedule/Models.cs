


namespace timeasy_api.src.Modules.teacher.UseCases.DeleteWorkSchedule;
public class Request
{
    public Guid Id { get; set; }
}


public class Response
{
    public string Message { get; set; } = "Horário Removido com sucesso";
}