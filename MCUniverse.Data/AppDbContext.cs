using Microsoft.EntityFrameworkCore;
using MCUniverse.Data.Entities;


namespace MCUniverse.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Student> Students { get; set; }

}
 

