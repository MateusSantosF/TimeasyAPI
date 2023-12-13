using Microsoft.EntityFrameworkCore;

namespace timeasy_api.src.Contexts;

public class TimeasyDbContext : DbContext
{
    public TimeasyDbContext(DbContextOptions<TimeasyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimeasyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
