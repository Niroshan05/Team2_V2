using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team2_LMS.Models
{
    public class EmployeeDB
    {
        [Key]
        public int EmployeeId { get; set; }
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
        [Required]
        [DataType(DataType.Date)]
       
        public DateTime DateJoined { get; set; }
        [Required]
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual ManagerDb ManagerDb { get; set; }
        [Required]
        public int LeaveBalance { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //image upload progress
        //[DataType(DataType.ImageUrl)]
        //public FileExtensionsAttribute Image { get; set; }

    }
}
