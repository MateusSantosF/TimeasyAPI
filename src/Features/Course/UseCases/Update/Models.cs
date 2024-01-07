

namespace timeasy_api.src.Modules.course.UseCases.Update;
public class Request
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int PeriodAmount { get; set; }
    public string Turn { get; set; }
    public string Period { get; set; }
}
public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O parametro Name é obrigatório.")
            .MinimumLength(5).WithMessage("Informe seu nome completo.");

        RuleFor(x => x.PeriodAmount)
            .GreaterThan(0)
            .WithMessage("A quantidade de Periodos deve ser maior que zero.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int PeriodAmount { get; set; }
    public string Turn { get; set; }
    public string Period { get; set; }
    public Guid InstituteId { get; set; }
}