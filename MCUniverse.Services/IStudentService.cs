using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data.Entities;
using MCUniverse.Models;

namespace MCUniverse.Services
{
    public interface IStudentService
    {

        Task<bool> RegisterStudentAsync(StudentRegistration model);
        Task<Student> GetStudentByEmailAsync(string email);
        Task<Student> GetStudentByUsernameAsync(string username);
        Task<IEnumerable<StudentDetails>> GetAllStudentsAsync();
        Task<StudentDetails> GetStudentByIdAsync(int studentId);
        Task<bool> DeleteStudentByIdAsync(int studentId);
        Task<bool> UpdateStudentByIdAsync(StudentUpdate model);




    }
}
