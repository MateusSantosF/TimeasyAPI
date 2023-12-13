using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace timeasy_api.src.Contexts.Mappings;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder
            .HasOne(r => r.Type)
            .WithMany(t => t.Rooms)
            .HasForeignKey(r => r.RoomTypeId);

        builder.HasIndex(room => room.Name).IsUnique();


        builder
            .HasMany(r => r.Timetables)
            .WithMany(t => t.Rooms);
    }
}

