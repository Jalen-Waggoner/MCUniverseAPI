using MCUniverse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCUniverse.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<FacultyEntity> Faculties { get; set; }
}
        
