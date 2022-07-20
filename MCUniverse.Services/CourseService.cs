using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Models;
using MCUniverse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

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
                StartTime = newCourse.StartTime,
                EndTime = newCourse.EndTime,
                ClassDays = newCourse.ClassDays,
                Credits = newCourse.Credits,
                Building = newCourse.Building,
                RoomNumber = newCourse.RoomNumber
            };
            _context.Courses.Add(course);
            var numChanges = await _context.SaveChangesAsync();
            return numChanges == 1;
        }

        public async Task<IEnumerable<CourseDetail>> ShowAllCourses()
        {
            var courses = await _context.Courses
                .Select(entity => new CourseDetail
                {
                    Name = entity.Name,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    ClassDays = entity.ClassDays,
                    Credits = entity.Credits,
                    Building = entity.Building,
                    RoomNumber = entity.RoomNumber
                }).ToListAsync();
            return courses;
        }

        public async Task<CourseDetail?> ShowCoursebyId(int id)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(e =>
                e.Id == id);
            return course is null ? null : new CourseDetail
            {
                Name = course.Name,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
                ClassDays = course.ClassDays,
                Credits = course.Credits,
                Building = course.Building,
                RoomNumber = course.RoomNumber
            };
        }

    };

}
