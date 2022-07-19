using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Team2_LMS.Models
{
    public class LeaveManagementDB
    {
        [Key]
        [Required]
        public int LeaveId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]

        public int EmployeeLeaveBalance { get; set; }
        [Required]
        public int Numberofdays { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]

        public string Reason { get; set; }
        


    }
}
