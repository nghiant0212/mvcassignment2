using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Assignment_ASP.NET_MVC2.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required.")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Required.")]

        public string? Gender { get; set; }
        [Required(ErrorMessage = "Required.")]

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Required.")]
        
        public string PhoneNumber { get; set;}
        [Required(ErrorMessage = "Required.")]

        public string BirthPlace { get; set; }
        [Required(ErrorMessage = "Required.")]

        public bool IsGraduated { get; set; }
    }
}