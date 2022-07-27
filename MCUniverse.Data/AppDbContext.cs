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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>()
            .HasData(
            new Faculty { Id = 1, UserName = "NicholasFury", Password = "EyePatch", FirstName = "Nicholas", LastName = "Fury", Email = "NickFury@MCUniversity.com", PhoneNumber = "(555)-650-6639", Gender = 0 },
            new Faculty { Id = 2, UserName = "TheTitan", Password = "50/50", FirstName = "Thanos", LastName = "Purpleman", Email = "Thanos@MCUniversity.com", PhoneNumber = "(555)-242-3649", Gender = 0 },
            new Faculty { Id = 3, UserName = "JaneFoster", Password = "ThorsAHunk", FirstName = "Jane", LastName = "Foster", Email = "JaneFoster@MCUniversity.com", PhoneNumber = "(555)-242-1277", Gender = (GenderEnum)1 },
            new Faculty { Id = 4, UserName = "AbrahamErskine", Password = "AmericaForever", FirstName = "Abraham", LastName = "Erskine", Email = "AbrahamErskine@MCUniversity.com", PhoneNumber = "(555)-242-4847", Gender = 0 },
            new Faculty { Id = 5, UserName = "ProfSelvig", Password = "UnderwearMan", FirstName = "Professor", LastName = "Selvig", Email = "ProfSelvig@MCUniversity.com", PhoneNumber = "(555)-532-5100", Gender = 0 });

        modelBuilder.Entity<CourseEntity>()
            .HasData(
            new CourseEntity { Id = 1, FacultyId = 1, Name = "Saving the World 101", StartTime = "9:00", EndTime = "10:00", ClassDays = "Monday, Wednesday, Friday", Credits = 3, Semester = 1, Building = "Philip Colson Memorial Hall", RoomNumber = 201 },
            new CourseEntity { Id = 2, FacultyId = 2, Name = "Metal Hearts 101", StartTime = "10:00", EndTime = "11:00", ClassDays = "Wednesday", Credits = 5, Semester = 1, Building = "Philip Colson Memorial Hall", RoomNumber = 201 },
            new CourseEntity { Id = 3, FacultyId = 3, Name = "I Am Groot", StartTime = "11:00", EndTime = "12:00", ClassDays = "Monday, Friday", Credits = 3, Semester = 2, Building = "Falcon's Nest", RoomNumber = 125 },
            new CourseEntity { Id = 4, FacultyId = 4, Name = "Infinity Stones 201", StartTime = "2:15", EndTime = "4:00", ClassDays = "Tuesday, Thursday", Credits = 3, Semester = 0, Building = "Philip Colson Memorial Hall", RoomNumber = 211 },
            new CourseEntity { Id = 5, FacultyId = 5, Name = "Catch Phrases 301", StartTime = "9:00", EndTime = "10:00", ClassDays = "Monday, Wednesday, Friday", Credits = 3, Semester = 1, Building = "Philip Colson Memorial Hall", RoomNumber = 154 },
            new CourseEntity { Id = 6, FacultyId = 3, Name = "Catch Phrases 101", StartTime = "3:00", EndTime = "4:00", ClassDays = "Thursday", Credits = 7, Semester = 1, Building = "Bifrost Keep", RoomNumber = 510 });

        modelBuilder.Entity<Student>()
            .HasData(
            new Student { Id = 1, Username = "SteveRogers", Password = "FREEDOM", DateOfBirth = new DateTime(1910 - 07 - 27), FullName = "Steven Rogers", Gender = "Male", Address = "1600 Pennsylvania Ave NW", Email = "SteveRogers@MCUniversity.com", PhoneNumber = "(555)-650-1234", OriginCountry = "United States of America", DateCreated = DateTime.Now, LastModified = DateTime.Now },
            new Student { Id = 2, Username = "BuckyBarnes", Password = "Soldier76", DateOfBirth = new DateTime(1905 - 12 - 27), FullName = "Bucky Barnes", Gender = "Male", Address = "846 Wakanda Ln", Email = "BuckyBoy@MCUniversity.com", PhoneNumber = "(555)-514-6542", OriginCountry = "United States of America", DateCreated = DateTime.Now, LastModified = DateTime.Now },
            new Student { Id = 3, Username = "SamWilly", Password = "CapForever", DateOfBirth = new DateTime(1983 - 07 - 26), FullName = "Samuel Wilson", Gender = "Male", Address = "355 Taldore Dr", Email = "WingMan@MCUniversity.com", PhoneNumber = "(555)-675-2548", OriginCountry = "United States of America", DateCreated = DateTime.Now, LastModified = DateTime.Now },
            new Student { Id = 4, Username = "PeterPiper", Password = "SpiderGuy", DateOfBirth = new DateTime(2005 - 10 - 07), FullName = "Peter Parker", Gender = "Male", Address = "658 Dog Breath Blvd", Email = "SpidyGuy@MCUniversity.com", PhoneNumber = "(555)-654-9873", OriginCountry = "United States of America", DateCreated = DateTime.Now, LastModified = DateTime.Now },
            new Student { Id = 5, Username = "WandaWitchin", Password = "MissYouVision", DateOfBirth = new DateTime(1993 - 09 - 15), FullName = "Wanda Maximoff", Gender = "Female", Address = "486 CrackBaby Ave", Email = "ScarletBitch@MCUniversity.com", PhoneNumber = "(555)-127-1237", OriginCountry = "Sokovia", DateCreated = DateTime.Now, LastModified = DateTime.Now });
    }
}