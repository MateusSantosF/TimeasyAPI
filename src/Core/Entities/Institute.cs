﻿
namespace timeasy_api.src.core.entities;

public class Institute : BaseEntity
{
    public string Name { get; set; }
    public TimeSpan OpenHour { get; set; }
    public TimeSpan CloseHour { get; set; }
    public bool Monday { get; set; }
    public bool Tuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Thursday { get; set; }
    public bool Friday { get; set; }
    public bool Saturday { get; set; }

    // EF Relations
    public virtual List<Interval> Intervals { get; set; }
    public virtual List<Course> Courses { get; set; }
    public virtual List<Timetable> Timetables { get; set; }
    public virtual List<Teacher> Teachers { get; set; }
    public virtual List<User> Users { get; set; }
}

