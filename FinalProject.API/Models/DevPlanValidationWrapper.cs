using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Models
{
    public class DevPlanValidationWrapper
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string StatusCode { get; set; }
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Due Date is required")]
        public string DueDate { get; set; }
    }
}
