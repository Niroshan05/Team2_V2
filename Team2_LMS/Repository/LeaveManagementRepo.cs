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
    public class LeaveManagementRepo : ILeaveManagementRepo
    {
        private readonly DataAccesser dataAccesser;
        private readonly IMapper mapper;

        public LeaveManagementRepo(DataAccesser dataAccesser, IMapper mapper)
        {
            this.dataAccesser = dataAccesser;
            this.mapper = mapper;
        }



        public async Task<int> AddNewLeave(LeaveManagementModel leavemanagementModel)
        {
            var data = mapper.Map<LeaveManagementDB>(leavemanagementModel);
            dataAccesser.leavemanagementDbs.Add(data);
            await dataAccesser.SaveChangesAsync();
            return 1;

        }

        public async Task<int> ApproveDeny(int? LeaveId, string Status, string ManagerComments)
        {
            var data =  dataAccesser.managerDbs.FromSqlRaw(
                $"alter table leavemanagementDbs status={Status}, managerComments={ManagerComments} where leaveId={LeaveId}").FirstOrDefault();
            return 1;
        }

        public async Task<List<LeaveManagementDB>> GetAllLeave()
        {
            var data = await dataAccesser.leavemanagementDbs.ToListAsync();
            return data;
        }

        public async Task RemoveLeave(int? LeaveId)
        {
            var data = await dataAccesser.leavemanagementDbs.FirstOrDefaultAsync(x => x.LeaveId == LeaveId);
            if (data != null)
            {
                dataAccesser.Remove(data);
            }
            await dataAccesser.SaveChangesAsync();
        }

        public async Task<List<LeaveManagementDB>> SearchByEmpId(int EmployeeId)
        {
            var data = await dataAccesser.leavemanagementDbs.Where(x => x.EmployeeId == EmployeeId).ToListAsync();
           // var maped = mapper.Map<LeaveManagementDB>(data);
            return data;
        }

        public async Task<LeaveManagementDB> SearchByLeaveId(int LeaveId)
        {
            var data = await dataAccesser.leavemanagementDbs.Where(x => x.LeaveId == LeaveId).FirstOrDefaultAsync();
            //var maped = mapper.Map<LeaveManagementDB>(data);
            return data;
        }

        public async Task<List<LeaveManagementDB>> ShowRepLeaves(int EmployeeId)
        {
            var data = await dataAccesser.leavemanagementDbs.Where(x => x.ManagerId == EmployeeId).ToListAsync();
            return data;

        }

        public async Task UpdateLeave(int? LeaveId, LeaveManagementDB leaveManagementDb)
        {
            var data = await dataAccesser.leavemanagementDbs.FirstOrDefaultAsync(x => x.LeaveId == LeaveId);
            if (data != null)
            {
                data.EmployeeId = leaveManagementDb.EmployeeId;
                data.ManagerId = leaveManagementDb.ManagerId;
                data.StartDate = leaveManagementDb.StartDate;
                data.EndDate = leaveManagementDb.EndDate;
                data.Numberofdays = leaveManagementDb.Numberofdays;
                data.Type = leaveManagementDb.Type;
                data.Status = leaveManagementDb.Status;
                data.Reason = leaveManagementDb.Reason;
                data.AppliedOn = leaveManagementDb.AppliedOn;
                data.ManagerComment = leaveManagementDb.ManagerComment;
                await dataAccesser.SaveChangesAsync();
            }
        }

    }
}
