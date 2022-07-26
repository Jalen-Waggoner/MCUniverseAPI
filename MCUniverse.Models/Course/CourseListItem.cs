using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.Course
{
    // Making a course model with a few details for a list of all courses
    public class CourseListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        public Season Semester { get; set; }
    }
}
