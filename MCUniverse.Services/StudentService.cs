using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Data.Entities;
using MCUniverse.Models;
using Microsoft.EntityFrameworkCore;

namespace MCUniverse.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterStudentAsync(StudentRegistration model)
        {
            if (await GetStudentByEmailAsync(model.Email) !=null || await GetStudentByUsernameAsync(model.Username) !=null)
                return false;

            var student = new Student
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            };

            _context.Students.Add(student);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges > 0;
        }

        private async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Email.ToLower() == email.ToLower());
        }

        private async Task<Student> GetStudentByUsernameAsync(string username)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Email.ToLower() == username.ToLower());
        }
    }
}
