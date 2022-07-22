using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Data.Entities;
using MCUniverse.Models;
using Microsoft.AspNetCore.Identity;
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
            if (await GetStudentByEmailAsync(model.Email) != null || await GetStudentByUsernameAsync(model.Username) != null)
                return false;

            var student = new Student
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                DateCreated = DateTime.Now,
                Address = model.Address,
                FullName = model.FullName,
                DateOfBirth = DateTime.Now,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                OriginCountry = model.OriginCountry,
                LastModified = DateTime.Now,

            };

            // password hasher
          /*   var passwordHasher = new PasswordHasher<Student>();
             student.Password = passwordHasher.HashPassword(student, model.Password);*/

            _context.Students.Add(student);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        // change these methods
        // helper method is for the Registration 
        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Email.ToLower() == email.ToLower());
        }
        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Username.ToLower() == username.ToLower());
        }


        public async Task<IEnumerable<StudentDetails>> GetAllStudentsAsync()
        {
            var students = await _context.Students 
                .Select(Student => new StudentDetails
            {
                Id = Student.Id,
                FullName = Student.FullName,
                Gender = Student.Gender,
                DateOfBirth = Student.DateOfBirth,
                Address = Student.Address,
                PhoneNumber = Student.PhoneNumber,
                OriginCountry = Student.OriginCountry,
                DateCreated = Student.DateCreated
                


            }).ToListAsync();

            return students;
        }


        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);

            var studentDetails = new StudentDetails
            {
                Id = student.Id,
                FullName = student.FullName,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                PhoneNumber = student.PhoneNumber,
                OriginCountry = student.OriginCountry,
                DateCreated = student.DateCreated,
                LastModified = student.LastModified
            };
            return studentDetails;
        }
        public async Task<bool> DeleteStudentByIdAsync(int studentId)
        {
            var Student = await _context.Students.FindAsync(studentId);
            _context.Students.Remove(Student);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> UpdateStudentByIdAsync(StudentUpdate model)
        {
            var Student = await _context.Students.FindAsync(model.Id);

            Student.FullName = model.FullName;
            Student.Gender = model.Gender;
            Student.DateOfBirth = model.DateOfBirth;
            Student.Address = model.Address;
            Student.PhoneNumber = model.PhoneNumber;
            Student.OriginCountry = model.OriginCountry;
            Student.LastModified = model.LastModified;
       
                        
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges > 0;
        }

    }
}



