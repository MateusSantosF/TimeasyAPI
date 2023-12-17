using Microsoft.EntityFrameworkCore;
using timeasy_api.src.Contexts;

namespace timeasy_api.src.Repository;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<Course?> GetAllWithSubjectsAsync(Guid courseId);
}

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{

    private DbSet<Course> _entitie;

    public CourseRepository(TimeasyDbContext context) : base(context)
    {
        _entitie = context.Set<Course>();
    }

    public Task<Course?> GetAllWithSubjectsAsync(Guid courseId)
    {
        return _entitie.AsNoTracking().Include(c => c.CourseSubject)
                                            .ThenInclude(cs => cs.Subject)
                        .Where(c => c.Id.Equals(courseId))
                        .FirstOrDefaultAsync();
    }
}