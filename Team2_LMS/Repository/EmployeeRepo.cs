using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.DataAccesslayer;
using Team2_LMS.Models;
using AutoMapper;

namespace Team2_LMS.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DataAccesser dataAccesser;
        private readonly IMapper mapper;

        public EmployeeRepo(DataAccesser dataAccesser,IMapper mapper)
        {
            this.dataAccesser = dataAccesser;
            this.mapper = mapper;
        }

       

        public async Task<int> AddNewEmp(EmployeeModel employeeModel)
        {
            var data = mapper.Map<EmployeeDB>(employeeModel);
            dataAccesser.employeeDBs.Add(data);
            await dataAccesser.SaveChangesAsync();
            return 1;

        }

        public async Task<List<EmployeeDB>> GetAllEmployee()
        {
            var data = await dataAccesser.employeeDBs.ToListAsync();
            return data;
        }

        public async Task<int> Login(string E_Mail, string Password)
        {
            var data = await dataAccesser.employeeDBs.FirstOrDefaultAsync(x => x.E_Mail == E_Mail&x.Password==Password);
            var map = mapper.Map<EmployeeDB>(data);
            return 1;
        }

        public async Task RemoveEmp(int? EmployeeId)
        {
            var data = await dataAccesser.employeeDBs.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            if (data != null) {
                dataAccesser.Remove(data);
            }
            await dataAccesser.SaveChangesAsync();
        }

        public async Task<EmployeeDB> SearchById(int EmployeeId)
        {
            var data = await dataAccesser.employeeDBs.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            var maped = mapper.Map<EmployeeDB>(data);
            return data;
        }

        public async Task UpdateEmp(int? EmployeeId, EmployeeDB employeeDB)
        {
            var data = await dataAccesser.employeeDBs.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            if(data!=null)
            {
                data.FirstName = employeeDB.FirstName;
                data.LastName = employeeDB.LastName;
                data.E_Mail = employeeDB.E_Mail;
                data.ContactNumber = employeeDB.ContactNumber;
                data.DateJoined = employeeDB.DateJoined;
                data.ManagerId = employeeDB.ManagerId;
                data.Department = employeeDB.Department;
                data.Password = employeeDB.Password;
                await dataAccesser.SaveChangesAsync();
            }
        }
        
    }
}
