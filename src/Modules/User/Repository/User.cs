using timeasy_api.src.modules.institute.Repository;

namespace timeasy_api.src.modules.user.Repository;
public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public AcessLevel AcessLevel { get; set; }

    // EF Relations
    public Guid InstituteId { get; set; }
    public Institute Institute { get; set; }
}
