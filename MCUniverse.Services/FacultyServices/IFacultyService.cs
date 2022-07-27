
using MCUniverse.Models.FacultyModels;
using MCUniverse.Models.Course;
using MCUniverse.Models.FacultyModels;
using MCUniverse.Models.FacultyModels;
using MCUniverse.Models.Course;
using MCUniverse.Models.FacultyModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Services.FacultyServices
{
    public interface IFacultyService
    {
        Task<bool> RegisterFacultyAysnc(FacultyCreate faculty);
        Task<FacultyDetail> GetFacultyByIdAsync(int facultyId);
        Task<IEnumerable<FacultyListItem>> GetAllFacultyAsync();
        Task<bool> UpdateFacultyAsync(FacultyUserInfoUpdate request);
        Task<bool> DeleteFacultyAsync(int facultyId);
        Task<IEnumerable<CourseListItem>> ListCoursesByFacultyIdAsync(int facultyId);
        Task<bool> AssignCourseToFacultyMemeberAsync(int courseId, int facultyId);
        Task<IEnumerable<FacultyDetail>> SearchFacultyByNameAsync(string search);
        Task<bool> UpdateFacultyUserNameAndPasswordAsync(FacultyLogInUpdate request);
    }
}
