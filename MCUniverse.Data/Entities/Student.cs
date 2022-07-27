using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MCUniverse.Data.Entities;


namespace MCUniverse.Data.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }           
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string OriginCountry { get; set; } = null!;
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime LastModified { get; set; }
        
       /* Many to many relationship with CourseEntity. Student can join multiply courses / multiple students can join one course and courses
        can have many students.*/
       /*EntityFramework automatically creates a joining table with the name of both Student & Coures entities.
        The joining table will be CourseEntityStudent(in database) with two primary keys StudentId and CourseId which 
       will be the Foreign keys*/


        public virtual List<CourseEntity> courses { get; set; } = new List<CourseEntity>();

       }

    }
    
