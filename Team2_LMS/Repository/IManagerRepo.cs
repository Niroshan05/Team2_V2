using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Team2_LMS.Repository
{
    public interface IManagerRepo
    {
        Task<List<ManagerDb>> GetAllManager();
        Task<ManagerDb> SearchById(int ManagerId);
        Task<int> AddNewManager(ManagerModel managerModel);
        Task RemoveManager(int? ManagerId);
        Task UpdateManager(int? ManagerId, ManagerDb managerDb);

    }
}