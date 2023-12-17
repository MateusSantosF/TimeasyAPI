﻿
namespace timeasy_api.src.core.entities;
public class Interval : BaseEntity
{
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }

    // EF Relations
    public Institute Institute { get; set; }

    public Guid InstituteId { get; set; }
}
