using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.Models;

namespace Team2_LMS.Repository
{
    public interface IManagerRepo
    {
        Task<List<ManagerDb>> GetAllManager();
        Task<ManagerDb> SearchById(int EmployeeId);
        Task<int> AddNewManager(ManagerModel managerModel);
        Task RemoveManager(int? EmployeeId);
        Task UpdateManager(int? EmployeeId, ManagerDb managerDb);
        

    }
}