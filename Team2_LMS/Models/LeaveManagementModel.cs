using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Team2_LMS.Models
{
    public class LeaveManagementModel
    {
        [Key]
        [Required]
        public int LeaveId { get; set; }
        //[Required]
        //public int EmployeeId { get; set; }
        //[Required]
        //public int ManagerId { get; set; }
        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        
        //public virtual EmployeeDB EmployeeDB { get; set; }
        [Required]
        [ForeignKey("ManagerId")]
        public int ManagerId { get; set; }
        
        //public virtual ManagerDb ManagerDb { get; set; }
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
