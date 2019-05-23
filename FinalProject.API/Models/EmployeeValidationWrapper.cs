using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Models
{
    public class EmployeeValidationWrapper
    {
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Middle Name is required")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Archived is required")]
        public bool Archived { get; set; }
        [Required(ErrorMessage = "Hire Date is required")]
        public string HireDate { get; set; }
    }
}
