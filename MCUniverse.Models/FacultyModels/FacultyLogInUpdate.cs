using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.FacultyModels
{
    public class FacultyLogInUpdate
    {
        [Required]
        [MinLength(6, ErrorMessage = "Error: {0} must contain at least {1} characters.")]
        [MaxLength(15, ErrorMessage = "Error: {0} must contain no more than {1} characters.")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Error: {0} must contain at least {1} characters.")]
        [MaxLength(15, ErrorMessage = "Error: {0} must contain no more than {1} characters.")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
