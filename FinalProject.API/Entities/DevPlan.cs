using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Entities
{
    public class DevPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusCode { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string DueDate { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
