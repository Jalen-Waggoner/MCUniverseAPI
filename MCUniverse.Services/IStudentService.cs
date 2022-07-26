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
        Task<bool> RegisterStudentAsync(StudentRegistration model);
        Task<StudentDetails> GetStudentByEmailAsync(string email);
        Task<IEnumerable<StudentDetails>> GetAllStudentsAsync();
        Task<StudentRegistration> GetStudentByUsernameAsync(string username);
        Task<StudentDetails> GetStudentByIdAsync(int studentId);
        Task<bool> DeleteStudentByIdAsync(int studentId);
        Task<bool> UpdateStudentByIdAsync(StudentUpdate model);
        Task<bool> EnrollingStudentById(int StudentId, int CourseId);
        Task<IEnumerable<CourseListItem>> GetCourseEnrollmentByIdAsync(int studentId);




    }
}
