using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NAA.Data.BEANS
{
    public class ApplicantBEAN
    {
        public ApplicantBEAN() { }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        [MinLength(3, ErrorMessage = "Name entered is too short.")]
        [MaxLength(50, ErrorMessage = "Name entered is too long.")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "Address is Required.")]
        [MinLength(0, ErrorMessage = "Address entered is too short.")]
        [MaxLength(50, ErrorMessage = "Name entered is too long.")]
        public string ApplicantAddress { get; set; }

        [Required(ErrorMessage = "Phone number is Required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address number is Required.")]
        [EmailAddress]
        public string Email { get; set; }
        public string UserId { get; set; }
       
    }
}
