﻿

namespace timeasy_api.src.core.entities;

public class CourseSubject : BaseEntity
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int Period { get; set; }
    public int WeeklyClassCount { get; set; }
}

