﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.DataAccesslayer;
using Team2_LMS.Models;
using AutoMapper;

namespace Team2_LMS.Repository
{
    public class ManagerRepo : IManagerRepo
    {
        private readonly DataAccesser dataAccesser;
        private readonly IMapper mapper;

        public ManagerRepo(DataAccesser dataAccesser, IMapper mapper)
        {
            this.dataAccesser = dataAccesser;
            this.mapper = mapper;
        }

        public async Task<int> AddNewManager(ManagerModel managerModel)
        {
            var data = mapper.Map<ManagerDb>(managerModel);
            dataAccesser.managerDbs.Add(data);
            await dataAccesser.SaveChangesAsync();
            return 1;

        }

        public async Task<List<ManagerDb>> GetAllManager()
        {
            var data = await dataAccesser.managerDbs.ToListAsync();
            return data;
        }
        public async Task<int> Login(string E_Mail, string Password)
        {
            var data = await dataAccesser.employeeDBs.FirstOrDefaultAsync(x => x.E_Mail == E_Mail & x.Password == Password);
            var map = mapper.Map<EmployeeDB>(data);
            return 1;
        }
        public async Task RemoveManager(int? EmployeeId)
        {
            var data = await dataAccesser.managerDbs.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            if (data != null)
            {
                dataAccesser.Remove(data);
            }
            await dataAccesser.SaveChangesAsync();
        }

        public async Task<ManagerDb> SearchById(int EmployeeId)
        {
            var data = await dataAccesser.managerDbs.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            var maped = mapper.Map<ManagerDb>(data);
            return data;
        }

        public async Task UpdateManager(int? EmployeeId, ManagerDb managerDb)
        {
            var data = await dataAccesser.managerDbs.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            if (data != null)
            {
                data.EmployeeId = managerDb.EmployeeId;
                data.FirstName = managerDb.FirstName;
                data.LastName = managerDb.LastName;
                data.E_Mail = managerDb.E_Mail;
                data.ContactNumber = managerDb.ContactNumber;
                data.Department = managerDb.Department;
                await dataAccesser.SaveChangesAsync();
            }
        }
    }
}
