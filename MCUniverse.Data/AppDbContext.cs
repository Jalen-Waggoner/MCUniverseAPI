using Microsoft.EntityFrameworkCore;

namespace MCUniverse.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public Dbset<CourseEntity> Courses { get; set; }
}
        
