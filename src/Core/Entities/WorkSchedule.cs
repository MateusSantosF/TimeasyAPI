
namespace timeasy_api.src.core.entities;
public class WorkSchedule : BaseEntity
{
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }

    // EF Relations
    public Teacher Teacher { get; set; }
    public Guid TeacherId { get; set; }
}
