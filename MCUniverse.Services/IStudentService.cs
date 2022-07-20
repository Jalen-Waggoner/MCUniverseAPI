using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Models;

namespace MCUniverse.Services
{
    public interface IStudentService
    {
        Task<bool> RegisterStudentAsync(StudentRegistration model);

    }
}
