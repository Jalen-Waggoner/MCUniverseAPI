using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models
{
    public class CourseDetail
    {
        public string Name { get; set; } = null!;
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string classDays { get; set; }
        public int Credits { get; set; }
        public string Building { get; set; } = null!;
        public int roomNumber { get; set; }
    }
}
