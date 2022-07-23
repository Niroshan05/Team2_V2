using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Team2_LMS.Models
{
    public class ManagerModel
    {
        [Key]
        public int sno{ get; set; }
        [Required]
        public int? EmployeeId { get; set; }

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
