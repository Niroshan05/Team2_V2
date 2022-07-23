using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.Models;

namespace Team2_LMS.Repository
{
    public interface ILeaveManagementRepo
    {
        Task<List<LeaveManagementDB>> GetAllLeave();
        Task<List<LeaveManagementDB>> SearchByEmpId(int EmployeeId);
        Task<List<LeaveManagementDB>> ShowRepLeaves(int EmployeeId);
        Task<int> AddNewLeave(LeaveManagementModel leavemanagementModel);
        Task RemoveLeave(int? LeaveId);
        Task UpdateLeave(int? LeaveId, LeaveManagementDB leavemanagementDb);
    }
}
