using MCUniverse.Data;
using MCUniverse.Data.Entities;
using MCUniverse.Models.Course;
using MCUniverse.Models.FacultyModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Services.FacultyServices;

public class FacultyService : IFacultyService
{
    private readonly AppDbContext _context;

    public FacultyService(AppDbContext context)
    {
        _context = context;
    }


    //Create a Faculty Member
    public async Task<bool> RegisterFacultyAysnc(FacultyCreate faculty)
    {
        var entity = new Faculty
        {
            UserName = faculty.UserName,
            Password = faculty.Password,
            FirstName = faculty.FirstName,
            LastName = faculty.LastName,
            Email = faculty.Email,
            PhoneNumber = faculty.PhoneNumber,
            Gender = faculty.Gender,
        };
        _context.Faculties.Add(entity);
        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }



    //GET Faculty by Id
    public async Task<FacultyDetail> GetFacultyByIdAsync(int facultyId)
    {
        var entity = await _context.Faculties.FindAsync(facultyId);
        if (entity == null)
            return null;

        var facultyDetail = new FacultyDetail
        {
            Id = entity.Id,
            UserName = entity.UserName,
            Email = entity.Email,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            PhoneNumber = entity.PhoneNumber,
        };
        return facultyDetail;
    }



    //Get List of All Faculty Members
    public async Task<IEnumerable<FacultyListItem>> GetAllFacultyAsync()
    {
        var faculties = await _context.Faculties.
            Select(f => new FacultyListItem
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
            }).ToListAsync();

        if (faculties == null)
            return null;



        return faculties;
    }



    //Update a Faculty Member By Id
    public async Task<bool> UpdateFacultyAsync(FacultyUserInfoUpdate request)
    {
        var faculty = await _context.Faculties.FindAsync(request.Id);

        faculty.Id = request.Id;
        faculty.Email = request.Email;
        faculty.FirstName = request.FirstName;
        faculty.LastName = request.LastName;
        faculty.PhoneNumber = request.PhoneNumber;
        faculty.Gender = request.Gender;

        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }



    //Delete a Faculty Member By Id
    public async Task<bool> DeleteFacultyAsync(int facultyId)
    {
        var faculty = await _context.Faculties.FindAsync(facultyId);

        if (faculty == null)
            return false;

        _context.Faculties.Remove(faculty);

        return await _context.SaveChangesAsync() == 1;
    }



    //Get List of All Courses Assigned to a Faculty Member By Id
    public async Task<IEnumerable<CourseListItem>> ListCoursesByFacultyIdAsync(int facultyId)
    {
        var courses = await _context.Courses.Where(c => c.FacultyId == facultyId)
            .Select(c => new CourseListItem
            {
                Id = c.Id,
                Name = c.Name,
                Credits = c.Credits,
                Semester = (Season)c.Semester,
            }).ToListAsync();

        if (courses.Count == 0)
            return null;

        return courses;
    }



    //Assign a Course to a Faculty Memeber By the Course Id and the Faculty Id
    public async Task<bool> AssignCourseToFacultyMemeberAsync(int courseId, int facultyId)
    {
        var course = await _context.Courses.FindAsync(courseId);

        course.FacultyId = facultyId;

        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }



    //Search for a Faculty Member By FirstName or LastName
    public async Task<IEnumerable<FacultyDetail>> SearchFacultyByNameAsync(string search)
    {
        if (search == null)
            return null;

        search = search.ToLower();
        var faculties = await _context.Faculties.Where(f =>
        f.FirstName.ToLower() == search ||
        f.LastName.ToLower() == search)
        .Select(f => new FacultyDetail
        {
            Id = f.Id,
            UserName = f.UserName,
            Email = f.Email,
            FirstName = f.FirstName,
            LastName = f.LastName,
            PhoneNumber = f.PhoneNumber,
        }
        ).ToListAsync();

        if (faculties.Count() == 0)
            return null;

        return faculties;
    }


    //Update Faculty UserName and Password
    public async Task<bool> UpdateFacultyUserNameAndPasswordAsync(FacultyLogInUpdate request)
    {
        var faculty = await _context.Faculties.FindAsync(request.Id);

        faculty.Id = request.Id;
        faculty.UserName = request.UserName;
        faculty.Password = request.Password;

        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }
}

