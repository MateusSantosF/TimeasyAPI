namespace timeasy_api.src.Core;

public class TokenConfiguration
{
    public int ExpirationHours { get; set; } = 2;
    public string SecretJwtKey { get; set; }
}
