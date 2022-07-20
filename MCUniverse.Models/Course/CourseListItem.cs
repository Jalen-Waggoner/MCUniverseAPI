using MCUniverse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;

namespace MCUniverse.Models.Course
{
    public class CourseListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        public Season Semester { get; set; }
    }
}
