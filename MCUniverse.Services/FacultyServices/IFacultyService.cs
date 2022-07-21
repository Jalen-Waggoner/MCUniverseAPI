﻿using MCUniverse.Models.FacultyModels;
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
    }
}