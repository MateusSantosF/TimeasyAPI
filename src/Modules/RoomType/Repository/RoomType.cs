using timeasy_api.src.modules.room.Repository;
using timeasy_api.src.modules.subject.Repository;

namespace timeasy_api.src.modules.roomType;
public class RoomType : BaseEntity
{
    public string Name { get; set; }
    public bool IsComputerLab { get; set; }
    public OperationalSystem? OperationalSystem { get; set; }

    // EF Relations
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
