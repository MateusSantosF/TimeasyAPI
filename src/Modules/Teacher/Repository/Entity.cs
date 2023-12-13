using timeasy_api.src.modules.institute.Repository;
using timeasy_api.src.modules.timetable.Repository;

namespace timeasy_api.src.modules.teacher.Repository;

public class Teacher : BaseEntity
{
    public string Registration { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public AcademicDegree AcademicDegree { get; set; }
    public int TeachingHours { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly IfspServiceTime { get; set; }
    public DateOnly CampusServiceTime { get; set; }

    // EF Relations
    public Guid InstituteId { get; set; }
    public Institute Institute { get; set; }
    public List<Timetable> Timetables { get; set; }
}
