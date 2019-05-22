using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Models
{
    public class DevPlanDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusCode { get; set; }
        public int EmployeeId { get; set; }
        public string DueDate { get; set; }
    }
}
