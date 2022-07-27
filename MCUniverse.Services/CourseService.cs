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
using MCUniverse.Models;

namespace MCUniverse.Services
{
    // Service class is connected to interface through dependency injection
    public class CourseService : ICourseService
    {

        // Referring to/calling the database to access the Courses table
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }



        // Method to create a new course entity

        // Using a bool to see if an entity was created and saved or not
        // Using the CourseCreate model to create a new CourseEntity
        public async Task<bool> CreateCourse(CourseCreate newCourse)
        {
            // Setting variable course equal to a new CourseEntity
            var course = new CourseEntity()
            {
                // Adding input to each property in the CourseCreate model
                // CourseEntity property = CourseCreate model.property
                Name = newCourse.Name,
                FacultyId = newCourse.FacultyId,
                StartTime = newCourse.StartTime,
                EndTime = newCourse.EndTime,
                ClassDays = newCourse.ClassDays,
                Credits = newCourse.Credits,

                // Using int helps identify that I want to use the Semester property in the CourseEntity
                Semester = (int)newCourse.Semester,
                Building = newCourse.Building,
                RoomNumber = newCourse.RoomNumber
            };

            // Adding new CourseEntity to Courses table in database
            _context.Courses.Add(course);

            // Saving changes to table and database
            // Returning true if CourseEntity was saved
            return await _context.SaveChangesAsync() == 1;
        }



        // Method to get list of all CourseEntities in the Courses table in the database

        // Using IEnumerable to make a list of models
        // Using CourseListItem model to show brief details of the CourseEntities in the table
        public async Task<IEnumerable<CourseListItem>> ShowAllCourses()
        {
            // returns list of courses to controller
            // for each CourseEntity in the Courses tables it is adding the data to the properties in the CourseListItem model
            return await _context.Courses

                // Selects all the CourseEntities in the Courses table and adds the properties to the CourseListItem model's properties
                // .Select is used to output data and it has to have a .ToList or .ToListAsync after it
                .Select(entity => new CourseListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Credits = entity.Credits,

                    // Using Season here helps identify that I want to use the Semester enum in the models
                    Semester = (Season)entity.Semester

                    // Makes each CourseListItem model made into a list
                }).ToListAsync();
        }




        // Method to get course by Id

        // Using the CourseDetail model to show all the details of that specific CourseEntity
        // Using course Id to find specific course in Courses table
        public async Task<CourseDetail> ShowCoursebyCourseIdAsync(int courseId)
        {

            // Setting course variable equal to Courses table in database
            var course = await _context.Courses

                // Using .Include to include the students list in the CourseEntity that the user is looking for
                .Include(entity => entity.students)

                // Finding course in Courses table that has the same course Id as the integer in the parameters
                // .FirstorDefaultAsync works like .Where except .Where can only list through items and not just find one item like .FirstorDefaultAsync
                //.FindAsync cannot be used after another LINQ function
                .FirstOrDefaultAsync(entity => entity.Id == courseId);

            
            

            // Checking if course variable has a CourseEntity or not (is null or not)
            if (course == null)

                // If course is null the method will return null to the controller
                return null;

            // This variable is set equal to the specific CourseEntity's faculty Id
            var FID = course.FacultyId;

            // The faculty Id is plugged into the private method below
            var name = await ShowFacultyName(FID);

            // If course variable is a CourseEntity, it adds the CourseEntity data to the properties in the CourseDetail model and returns it to the controller
            return new CourseDetail
            {

                // property in CourseDetail model = CourseEntity.property
                Id = course.Id,

                // This output uses the private function to find the faculty's name using their id
                Professor = name.FullName,
                Name = course.Name,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
                ClassDays = course.ClassDays,
                Credits = course.Credits,
                Semester = (Season)course.Semester,
                Building = course.Building,
                RoomNumber = course.RoomNumber,

                // This counts the students in the list of the CourseEntity
                Students = course.students.Count()
            };
        }




        // Method to get course(s) taught by a faculty member by their faculty Id
        public async Task<IEnumerable<CourseListItem>> ShowAllCoursesByFacultyIdAsync(int facultyId)
        {
            // Returns list of CourseListItem models that contain the facutlty Id to the controller

            return await _context.Courses

                // Finds CourseEntity in Courses in that has the same faculty id as the parameter
                // Cannot use .FindAsync because facultyId is not a primary key in the CourseEntity
                // .Where LINQ function is similar to .FirstorDefaultAsync but .FirstorDefaultAsync cannot list multiple courses, but .Where can
                .Where(entity => entity.FacultyId == facultyId)
                .Select(entity => new CourseListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Credits = entity.Credits,
                    Semester = (Season)entity.Semester
                }).ToListAsync();
        }




        // Method to search for course(s) by credits
        public async Task<IEnumerable<CourseListItem>> ShowAllCoursesByCreditsAsync(int credits)
        {
            return await _context.Courses
                .Where(entity => entity.Credits == credits)
                .Select(entity => new CourseListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Credits = entity.Credits,
                    Semester = (Season)entity.Semester
                }).ToListAsync();
        }

        // Method to search for course(s) by the semester
        public async Task<IEnumerable<CourseListItem>> ShowAllCoursesBySemesterAsync(int semester)
        {
            var courses = await _context.Courses
                .Where(entity => (int)entity.Semester == semester)
                .Select(entity => new CourseListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Credits = entity.Credits,
                    Semester = (Season)entity.Semester
                }).ToListAsync();
            return courses;
        }



        // Method to search for courses by full or partial name of the course
        public async Task<IEnumerable<CourseListItem>> ShowCourseByNameAsync(string keyword)
        {
            return await _context.Courses
                .Where(c => c.Name

                // .Contains LINQ function looks for partial matches in the CourseEntity.Name property (LIKE function in SQL)
                .Contains(keyword))

                .Select(c => new CourseListItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    Credits = c.Credits,
                    Semester = (Season)c.Semester,
                }).ToListAsync();
        }




        // Method to update a course by the courseId
        public async Task<bool> UpdateCourseAsync(int courseId, CourseUpdate adjCourse)
        {
            // Finds CourseEntity in Courses table that has the courseId in the parameters
            var course = await _context.Courses

                // Finding CourseEntity based on courseId
                // FindAsync only finds primary keys, cannot be used before or after other LINQ functions
                .FindAsync(courseId);

            if (course is null)
            {
                return false;
            }

            // CourseEntity.property equals new updated property
            course.FacultyId = adjCourse.FacultyId;
            course.StartTime = adjCourse.StartTime;
            course.EndTime = adjCourse.EndTime;
            course.Building = adjCourse.Building;
            course.RoomNumber = adjCourse.RoomNumber;

            return await _context.SaveChangesAsync() == 1;
        }




        // Method to delete CourseEntity from Courses table by courseId
        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses
                .FindAsync(courseId);
            if (course == null)
                return false;

            // Removes course variable(CourseEntity) from Courses table
            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync() == 1;
        }




        // Method to show list of students enrolled in a course
        public async Task<IEnumerable<StudentDetails>> ShowStudentsbyCourseIdAsync(int courseId)
        {
            var course = await _context.Courses

                // Using .Include LINQ function to include virtual student table from CourseEntity
                .Include(entity => entity.students)

                // .FirstorDefaultAsync LINQ function can be used to find any property and it only finds the first entity and cannot call multiple entites and cannot be added to a list, it cannot be used with bool task, it can be used after other LINQ functions but not before
                .FirstOrDefaultAsync(entity => entity.Id == courseId);

            if (course == null)
                return null;

            // Returns list of each student's details in the course
            return course.students
                .Select(e => new StudentDetails
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Gender = e.Gender,
                    DateOfBirth = e.DateOfBirth,
                    Address = e.Address,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    OriginCountry = e.OriginCountry,
                    DateCreated = e.DateCreated
                }).ToList();
        }


        // Private method to get faculty names from faculty Id
        private async Task<FacultyName> ShowFacultyName(int facultyId)
        {
            var name = await _context.Courses
                .Include(entity => entity.faculty)
                .FirstOrDefaultAsync(entity => entity.faculty.Id == facultyId);
            if (name == null)
                return null;
            return new FacultyName
                {

                // FullName is set to the faculty FirstName property plus the faculty LastName property
                    FullName = name.faculty.FirstName + " " + name.faculty.LastName
                };
        }
    }
}

