using MCUniverse.Data.Entities;
using MCUniverse.Models;
using MCUniverse.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Services
{
    public interface ICourseService
    {
        Task<bool> CreateCourse(CourseCreate newCourse);
        Task<IEnumerable<CourseListItem>> ShowAllCourses();
        Task<CourseDetail> ShowCoursebyCourseIdAsync(int courseId);
        Task<IEnumerable<CourseListItem>> ShowAllCoursesByFacultyIdAsync(int facultyId);
        Task<IEnumerable<CourseListItem>> ShowAllCoursesByCreditsAsync(int credits);
        Task<IEnumerable<CourseListItem>> ShowAllCoursesBySemesterAsync(Season semester);
        Task<bool> UpdateCourseAsync(CourseUpdate adjCourse);
        Task<bool> DeleteCourseAsync(int courseId);
    }
}
