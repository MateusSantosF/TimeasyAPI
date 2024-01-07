

namespace timeasy_api.src.Modules.user.UseCases.signin;
public class Request
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class Validator : Validator<Request>
{
    public Validator()
    {

        RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Informe a senha por favor.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
}