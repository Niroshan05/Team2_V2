using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.Models;

namespace Team2_LMS.Repository
{
    public interface ICeoRepo
    {
        Task<List<CeoDB>> GetAllCeo();
        Task<CeoDB> SearchById(int CeoId);
        Task<int> AddNewCeo(CeoModel ceoModel);
        Task RemoveCeo(int? CeoId);
        Task UpdateCeo(int? CeoId, CeoDB ceoDB);
    }
}
