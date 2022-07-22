/*using MCUniverse.Data;
using MCUniverse.Data.Entities;
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

    public async Task<bool> RegisterFacultyAysnc(FacultyCreate faculty)
    {
        if (await GetFacultyByEmailAsync(faculty.Email) != null || await GetFacultyByUserNameAsync(faculty.UserName) != null)
            return false;

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


    public async Task<bool> UpdateFacultyAsync(FacultyUpdate request)
    {
        if (await GetFacultyByEmailAsync(request.Email) != null || await GetFacultyByUserNameAsync(request.UserName) != null)
            return false;

        var faculty = await _context.Faculties.FindAsync(request.Id);

        faculty.UserName = request.UserName;
        faculty.Password = request.Password;
        faculty.Email = request.Email;
        faculty.FirstName = request.FirstName;
        faculty.LastName = request.LastName;
        faculty.PhoneNumber = request.PhoneNumber;
        faculty.Gender = request.Gender;
        
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }



    public async Task<bool> DeleteFacultyAsync(int facultyId)
    {
        var faculty = await _context.Faculties.FindAsync(facultyId);

        if (faculty == null)
            return false;

        _context.Faculties.Remove(faculty);

        return await _context.SaveChangesAsync() == 1;
    }


    public async Task<Faculty> GetFacultyByEmailAsync(string email)
    {
        return await _context.Faculties.FirstOrDefaultAsync(f => f.Email.ToLower() == email.ToLower());
    }

    public async Task<Faculty> GetFacultyByUserNameAsync(string userName)
    {
        return await _context.Faculties.FirstOrDefaultAsync(f => f.UserName.ToLower() == userName.ToLower());
    }
}
*/
