
namespace timeasy_api.src.core.entities;

public class Teacher : BaseEntity
{
    public string Registration { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public virtual List<WorkSchedule> WorkSchedule { get; set; } = [];
    // EF Relations
    public Guid InstituteId { get; set; }
    public Institute Institute { get; set; }
    public List<Timetable> Timetables { get; set; }
}
