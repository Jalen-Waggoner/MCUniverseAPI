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
        public string startTime { get; set; } = null!;
        public string endTime { get; set; } = null!;
        public string classDays { get; set; } = null!;
        public int Credits { get; set; }
        public string Building { get; set; } = null!;
        public int roomNumber { get; set; }
    }
}
