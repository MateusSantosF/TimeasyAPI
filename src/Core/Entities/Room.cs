

namespace timeasy_api.src.core.entities;
public class Room : BaseEntity
{
    public string Name { get; set; }
    public string Block { get; set; }
    public int Capacity { get; set; }
    public Guid RoomTypeId { get; set; }
    public RoomType Type { get; set; }

    // EF Relations
    public virtual List<Timetable> Timetables { get; set; }

}
