using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Data.Entities;
using MCUniverse.Models;
using MCUniverse.Models.Course;
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

            var student = new Student()
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
                LastModified = DateTime.Now
            };

            // password hasher
            /*   var passwordHasher = new PasswordHasher<Student>();
               student.Password = passwordHasher.HashPassword(student, model.Password);*/

            _context.Students.Add(student);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }


        public async Task<StudentDetails> GetStudentByEmailAsync(string email)
        {
            var student = await _context.Students
            .FirstOrDefaultAsync(student => student.Email.ToLower() == email.ToLower());
            if (student == null)
                return null;
            var studentDetails = new StudentDetails
            {
                Id = student.Id,
                Email = student.Email,
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
        public async Task<StudentRegistration> GetStudentByUsernameAsync(string username)
        {
            var student = await _context.Students
           .FirstOrDefaultAsync(student => student.Username.ToLower() == username.ToLower());
            if (student == null)
                return null;

            var studentregistration = new StudentRegistration
            {
                Username = student.Username,
                Email = student.Email,
                Password = student.Password,
                DateCreated = DateTime.Now,
                Address = student.Address,
                FullName = student.FullName,
                DateOfBirth = DateTime.Now,
                Gender = student.Gender,
                PhoneNumber = student.PhoneNumber,
                OriginCountry = student.OriginCountry,
                LastModified = student.LastModified

            };
            return studentregistration;

        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Select(Student => new StudentDetails
                {
                    Id = Student.Id,
                    Email = Student.Email,
                    FullName = Student.FullName,
                    Gender = Student.Gender,
                    DateOfBirth = Student.DateOfBirth,
                    Address = Student.Address,
                    PhoneNumber = Student.PhoneNumber,
                    OriginCountry = Student.OriginCountry,
                    DateCreated = Student.DateCreated,
                    LastModified = Student.LastModified


                }).ToListAsync();

            return students;
        }

        // Asynchronously finds an entity with the given primary key values (StudentId)
        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);

            var studentDetails = new StudentDetails
            {
                Id = student.Id,
                Email = student.Email,
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
            var student = await _context.Students.FindAsync(model.Id);
            student.FullName = model.FullName;
            student.Email = model.Email;
            student.Gender = model.Gender;
            student.DateOfBirth = model.DateOfBirth;
            student.Address = model.Address;
            student.PhoneNumber = model.PhoneNumber;
            student.OriginCountry = model.OriginCountry;
            student.LastModified = DateTime.Now;


            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> EnrollingStudentById(int StudentId, int CourseId)
        {
            Student student = await _context.Students

                .Include(Student => Student.courses)
                .Where(Student => Student.Id == StudentId)
                .FirstOrDefaultAsync();
            if (student == null)
                return false;

            CourseEntity entity = await _context.Courses
                .Where(entity => entity.Id == CourseId)
                .FirstOrDefaultAsync();
            if (entity == null)
                return false;

            //adding student to courseEntity & also adding courseEntity to student
            student.courses.Add(entity);
            //now adding student to courses
            entity.students.Add(student);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<CourseListItem>> GetCourseEnrollmentByIdAsync(int studentId)
        {
            var student = await _context.Students.Include(student => student.courses)
                .FirstOrDefaultAsync(e => e.Id == studentId);
            if (student == null)
                return null;
            List<CourseListItem> CourseEnrollmentInfo = student.courses.Select(s => new CourseListItem
            {
                Id = s.Id,
                Name = s.Name,
                Credits = s.Credits,
                Semester = (Season)s.Semester

            }).ToList();
            return CourseEnrollmentInfo;

        }

        public async Task<bool> UpdateCourseEnrollmentByIdAsync(int studentId, int oldCourseId, int newCourseId)
        {
            // get the student to change; include his courses
          var student = await _context.Students
            .Include(student => student.courses)
            .Where(student => student.Id == studentId)
            .FirstOrDefaultAsync();
            if (student == null)
                return false;

            // Stop the course
            var oldCourse = student.courses
            .Where(course => course.Id == oldCourseId)
            .FirstOrDefault();

            if (oldCourse != null)
            {
                // This Student follows this cours; stop it:
                student.courses.Remove(oldCourse);
            }

            var newCourse = await _context.Courses
            .Where(course => course.Id == newCourseId)
             .FirstOrDefaultAsync();

            // only start the course if course exists and not already following
            if (newCourse != null && !student.courses.Contains(newCourse))
            {
                student.courses.Add(newCourse);
            }

            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteStudentEnrollmentByIdAsync(int studentId, int oldCourseId)
        {
          var student = await _context.Students
         .Include(student => student.courses)
         .Where(student => student.Id == studentId)
         .FirstOrDefaultAsync();
            if (student == null)
                return false;
            // Stop the course
            var oldCourse = student.courses
            .Where(course => course.Id == oldCourseId)
            .FirstOrDefault();

            if (oldCourse != null)
            {
                // This Student follows this cours; stop it:
                student.courses.Remove(oldCourse);
            }

           return await _context.SaveChangesAsync() == 1;

        }
    }
}

      




