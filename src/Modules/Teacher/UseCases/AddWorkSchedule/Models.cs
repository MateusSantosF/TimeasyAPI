


namespace timeasy_api.src.Modules.teacher.UseCases.AddWorkSchedule;
public class Request
{
    public Guid Id { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
}


public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x)
              .Must(request =>
              {
                  TimeSpan duration = request.End.ToTimeSpan() - request.Start.ToTimeSpan();
                  TimeSpan minimumDuration = TimeSpan.FromMinutes(50);
                  return duration >= minimumDuration;
              })
              .WithMessage("O intervalo permitido é de 50 minutos.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
}