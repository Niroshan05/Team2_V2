using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team2_LMS.Models
{
    public class ManagerDb
    {
        [Key]
        public int sno { get; set; }
        [Required]
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual EmployeeDB Employeedb { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string E_Mail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long ContactNumber { get; set; }
        [Required]
        public string Department { get; set; }
        
    }
}
