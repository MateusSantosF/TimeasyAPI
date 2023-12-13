using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace timeasy_api.src.core.entities;
public class Course : BaseEntity
{
    public string Name { get; set; }
    public int PeriodAmount { get; set; }
    public Turn Turn { get; set; }
    public PeriodType Period { get; set; }
    public List<CourseSubject> CourseSubject { get; } = new();
    public Guid InstituteId { get; set; }
    public virtual Institute Institute { get; set; }

    // EF Relation
    public virtual List<TimetableCourses> TimetableCourses { get; set; }
    public virtual List<TimetableSubjects> TimetableSubjects { get; set; }

}
