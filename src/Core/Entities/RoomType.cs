
namespace timeasy_api.src.core.entities;
public class RoomType : BaseEntity
{
    public string Name { get; set; }
    public bool IsComputerLab { get; set; }
    public OperationalSystem? OperationalSystem { get; set; }

    // EF Relations
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public Guid InstituteId { get; set; }
    public virtual Institute Institute { get; set; }
}
