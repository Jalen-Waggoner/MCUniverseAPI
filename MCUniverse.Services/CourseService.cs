using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MCUniverse.Models.Course;

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
                FacultyId = newCourse.FacultyId,
                StartTime = newCourse.StartTime,
                EndTime = newCourse.EndTime,
                ClassDays = newCourse.ClassDays,
                Credits = newCourse.Credits,
                Semester = newCourse.Semester,
                Building = newCourse.Building,
                RoomNumber = newCourse.RoomNumber
            };
            _context.Courses.Add(course);
            var numChanges = await _context.SaveChangesAsync();
            return numChanges == 1;
        }

        public async Task<IEnumerable<CourseListItem>> ShowAllCourses()
        {
            var courses = await _context.Courses
                .Select(entity => new CourseListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Credits = entity.Credits,
                    Semester = entity.Semester
                }).ToListAsync();
            return courses;
        }

        public async Task<CourseDetail?> ShowCoursebyCourseIdAsync(int courseId)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(e =>
                e.Id == courseId);
            return course is null ? null : new CourseDetail
            {
                Id = course.Id,
                Name = course.Name,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
                ClassDays = course.ClassDays,
                Credits = course.Credits,
                Semester = course.Semester,
                Building = course.Building,
                RoomNumber = course.RoomNumber
            };
        }

        public async Task<IEnumerable<CourseListItem>> ShowAllCoursesByFacultyIdAsync(int facultyId)
        {
            var courses = await _context.Courses
                .Where(entity => entity.FacultyId == facultyId)
                .Select(entity => new CourseListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Credits = entity.Credits,
                    Semester = entity.Semester
                }).ToListAsync();
            return courses;
        }
        
        public async Task<bool> UpdateCourseAsync(CourseUpdate adjCourse)
        {
            var course = await _context.Courses.FindAsync(adjCourse.Id);

            if (course is null)
            {
                return false;
            }
            course.StartTime = adjCourse.StartTime;
            course.EndTime = adjCourse.EndTime;
            course.Building = adjCourse.Building;
            course.RoomNumber = adjCourse.RoomNumber;

            var numChanges = await _context.SaveChangesAsync();
            return numChanges == 1;
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync() == 1;
        }

}

