using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCUniverse.Data.Entities
{
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Faculty")]
        public int Faculty_id {get; set;}
        [Required]
        public string Name {get; set;} = null!;
        [Required]
        public int StartTime {get; set;}
        [Required]
        public int EndTime {get; set;}
        [Required]
        public DayOfWeek ClassDay {get; set;}
        [Required]
        public int Credits {get; set;}
        [Required]
        public string Building {get; set;} = null!;
        [Required]
        public int RoomNumber {get; set;}
        public List<Student> Students { get; set; } = new List<Student>();
    }
}