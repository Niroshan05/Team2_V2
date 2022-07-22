using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team2_LMS.Models
{
    public class LeaveManagementDB
    {
        [Key]
        [Required]
        public int LeaveId { get; set; }
        //[Required]
        //public int EmployeeId { get; set; }
        //[Required]
        //public int ManagerId { get; set; }
        //adding foreign key
        [Required]
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual EmployeeDB Employeedb { get; set; }
        [Required]
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual ManagerDb ManagerDb { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public int Numberofdays { get; set; }
        [Required]
        public string Type { get; set; }  
        [Required]
        public string Status { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AppliedOn { get; set; }
        public string ManagerComment { get; set; }



    }
}
