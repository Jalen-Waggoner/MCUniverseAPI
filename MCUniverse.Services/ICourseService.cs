
using MCUniverse.Models;
using MCUniverse.Data.Entities;
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
        // Add tasks from courseService class so that they can be called from the controller
        Task<bool> CreateCourse(CourseCreate newCourse);
        Task<IEnumerable<CourseListItem>> ShowAllCourses();
        Task<CourseDetail> ShowCoursebyCourseIdAsync(int courseId);
        Task<IEnumerable<CourseListItem>> ShowAllCoursesByFacultyIdAsync(int facultyId);
        Task<IEnumerable<CourseListItem>> ShowAllCoursesByCreditsAsync(int credits);
        Task<IEnumerable<CourseListItem>> ShowAllCoursesBySemesterAsync(int semester);
        Task<IEnumerable<CourseListItem>> ShowCourseByNameAsync(string keyword);
        Task<bool> UpdateCourseAsync(int courseId, CourseUpdate adjCourse);
        Task<bool> DeleteCourseAsync(int courseId);
        Task<IEnumerable<StudentDetails>> ShowStudentsbyCourseIdAsync(int courseId);
        
    }
}
