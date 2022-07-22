<<<<<<< HEAD
﻿/*using MCUniverse.Models.FacultyModels;
=======
﻿using MCUniverse.Models.Course;
using MCUniverse.Models.FacultyModels;
>>>>>>> 779fb81bc88aaa0ebfd0e4423d428a8cd51b3b24
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
        Task<bool> UpdateFacultyAsync(FacultyUpdate facultyUpdate);
        Task<bool> DeleteFacultyAsync(int facultyId);
        Task<IEnumerable<CourseListItem>> ListCoursesByFacultyIdAsync(int facultyId);
        Task<bool> AssignCourseToFacultyMemeberAsync(int courseId, int facultyId);
        Task<IEnumerable<FacultyDetail>> SearchFacultyByNameAsync(string search);
    }
}*/
