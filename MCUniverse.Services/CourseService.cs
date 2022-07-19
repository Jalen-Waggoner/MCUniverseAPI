using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Models;
using MCUniverse.Data.Entities;

namespace MCUniverse.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCourse(CourseCreate newCourse)
        {
            var course = new CourseEntity()
            {
                Name = newCourse.Name,
                startTime = newCourse.startTime,
                endTime = newCourse.endTime,
                ClassDay = newCourse.ClassDay,
                Credits = newCourse.Credits,
                Building = newCourse.Building,
                RoomNumber = newCourse.RoomNumber
            };
            _context.Courses.Add(course);
            var numChanges = await _context.SaveChangesAsync();
            return numChanges == 1;
        }
    }
}
