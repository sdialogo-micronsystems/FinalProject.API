using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public bool Archived { get; set; }
        [Required]
        public string HireDate { get; set; }

        //public virtual IList<DevPlan> DevPlans { get; private set; }

        //public Employee(IList<DevPlan> devPlans)
        //{
        //    DevPlans = devPlans;
        //}
    }
}
