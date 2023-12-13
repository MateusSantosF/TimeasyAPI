
namespace timeasy_api.src.core.entities;

public class Timetable : BaseEntity
{
    public string Name { get; set; }
    public DateOnly CreateAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimetableStatus Status { get; set; }

    // EF Relations
    public Guid InstituteId { get; set; }
    public Institute Institute { get; set; }

    public virtual List<TimetableSubjects> TimetableSubjects { get; set; }
    public virtual List<TimetableCourses> TimetableCourses { get; set; }
    public virtual List<Room> Rooms { get; set; }
    public virtual List<Teacher> Teachers { get; set; }
}

public class TimetableCourses
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid TimetableId { get; set; }
    public Timetable Timetable { get; set; }
    public bool Monday { get; set; }
    public bool Tuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Thursday { get; set; }
    public bool Friday { get; set; }
    public bool Saturday { get; set; }
}

