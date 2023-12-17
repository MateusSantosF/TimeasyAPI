

namespace timeasy_api.src.core.entities;
public class Subject : BaseEntity
{
    public string Acronym { get; set; }
    public string Name { get; set; }
    public SubjectComplexity Complexity { get; set; }
    public RoomType RoomType { get; set; }
    public Guid RoomTypeId { get; set; }

    //EF Relations
    public virtual List<CourseSubject> CourseSubject { get; set; }
    public virtual List<TimetableSubjects> TimetableSubjects { get; set; }
    public Guid InstituteId { get; set; }
    public virtual Institute Institute { get; set; }

}

public class TimetableSubjects
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid TimetableId { get; set; }
    public Guid SubjectId { get; set; }
    public bool IsDivided { get; set; } = false;
    public int DividedCount { get; set; }
    public int StudentsCount { get; set; }

    // EF Relations
    public Course Course { get; set; }
    public Subject Subject { get; set; }
    public Timetable Timetable { get; set; }
}


