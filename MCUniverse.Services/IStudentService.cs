using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data.Entities;
using MCUniverse.Models;
using MCUniverse.Models.Course;

namespace MCUniverse.Services
{
    public interface IStudentService
    {
        // School website registration 
        Task<bool> RegisterStudentAsync(StudentRegistration model);
        Task<StudentDetails> GetStudentByIdAsync(int studentId);
        Task<IEnumerable<StudentDetails>> GetAllStudentsAsync();
        Task<StudentDetails> GetStudentByEmailAsync(string email);
        Task<StudentRegistration> GetStudentByUsernameAsync(string username);
        Task<bool> UpdateStudentByIdAsync(int StudentId, StudentUpdate model);
        Task<bool> DeleteStudentByIdAsync(int studentId);

        // Course enrollment
        Task<bool> EnrollingStudentById(int StudentId, int CourseId);
        Task<IEnumerable<CourseListItem>> GetCourseEnrollmentByIdAsync(int studentId);
        Task<bool> UpdateCourseEnrollmentByIdAsync(int studentId, int oldCourseId, int newCourseId);
        Task<bool> DeleteStudentEnrollmentByIdAsync(int studentId, int oldCourseId);




    }
}
