﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using timeasy_api.src.modules.subject.Repository;

namespace timeasy_api.src.Contexts.Mappings;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder
            .HasOne(s => s.RoomType)
            .WithMany(rt => rt.Subjects)
            .HasForeignKey(s => s.RoomTypeId);

        builder.HasIndex(s => s.Name).IsUnique();
    }
}

