

namespace timeasy_api.src.Modules.user.UseCases.Create;
public class Request
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string InstituteName { get; set; }
    public string CloseHour { get; set; }
    public string OpenHour { get; set; }
    public bool Monday { get; set; }
    public bool Tuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Thursday { get; set; }
    public bool Friday { get; set; }
    public bool Saturday { get; set; }

}
public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("O parametro Nome é obrigatório.")
            .MinimumLength(5).WithMessage("Informe seu nome completo.");

        RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("As senhas não coincidem");

        RuleFor(x => x.InstituteName)
         .NotEmpty().WithMessage("O nome da instituição de ensino é obrigatória.")
         .MinimumLength(3).WithMessage("Nome da instituição muito curto!")
         .MaximumLength(100).WithMessage("Nome da instituição muito longo!");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public Guid InstituteId { get; set; }
    public string InstituteName { get; set; }
    public TimeSpan CloseHour { get; set; }
    public TimeSpan OpenHour { get; set; }
    public bool Monday { get; set; }
    public bool Tuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Thursday { get; set; }
    public bool Friday { get; set; }
    public bool Saturday { get; set; }

}