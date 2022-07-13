using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.Models;

namespace Team2_LMS.Repository
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDB>> GetAllEmployee();
    }
}
