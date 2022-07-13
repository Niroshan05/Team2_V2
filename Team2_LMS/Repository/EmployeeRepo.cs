using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.DataAccesslayer;
using Team2_LMS.Models;

namespace Team2_LMS.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DataAccesser dataAccesser;

        public EmployeeRepo(DataAccesser dataAccesser)
        {
            this.dataAccesser = dataAccesser;
        }
        public async Task<List<EmployeeDB>> GetAllEmployee()
        {
            var data = await dataAccesser.employeeDBs.ToListAsync();
            return data;
        }
    }
}
