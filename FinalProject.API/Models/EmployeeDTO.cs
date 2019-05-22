using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool Archived { get; set; }
        public string HireDate { get; set; }
        //public int NumberOfAssignedDevPlans
        //{
        //    get
        //        {
        //            return AssignedDevPlans.Count;
        //        }
        //}

        //public ICollection<DevPlanDTO> AssignedDevPlans { get; set; } = new List<DevPlanDTO>();
    }
}
