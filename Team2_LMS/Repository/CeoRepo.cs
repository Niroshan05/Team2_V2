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
    
        public class CeoRepo : ICeoRepo
        {
            private readonly DataAccesser dataAccesser;
            private readonly IMapper mapper;

            public CeoRepo(DataAccesser dataAccesser, IMapper mapper)
            {
                this.dataAccesser = dataAccesser;
                this.mapper = mapper;
            }

            public async Task<int> AddNewCeo(CeoModel ceoModel)
            {
                var data = mapper.Map<CeoDB>(ceoModel);
                dataAccesser.ceoDBs.Add(data);
                await dataAccesser.SaveChangesAsync();
                return 1;

            }

            public async Task<List<CeoDB>> GetAllCeo()
            {
                var data = await dataAccesser.ceoDBs.ToListAsync();
                return data;
            }

            public async Task RemoveCeo(int? CeoId)
            {
                var data = await dataAccesser.ceoDBs.FirstOrDefaultAsync(x => x.CeoId == CeoId);
                if (data != null)
                {
                    dataAccesser.Remove(data);
                }
                await dataAccesser.SaveChangesAsync();
            }

            public async Task<CeoDB> SearchById(int CeoId)
            {
                var data = await dataAccesser.ceoDBs.FirstOrDefaultAsync(x => x.CeoId == CeoId);
                var maped = mapper.Map<CeoDB>(data);
                return data;
            }

            public async Task UpdateCeo(int? CeoId, CeoDB ceoDB)
            {
                var data = await dataAccesser.ceoDBs.FirstOrDefaultAsync(x => x.CeoId == CeoId);
                if (data != null)
                {
                    data.FirstName = ceoDB.FirstName;
                    data.LastName = ceoDB.LastName;
                    data.E_Mail = ceoDB.E_Mail;
                    data.ContactNumber = ceoDB.ContactNumber;
                    data.DateJoined = ceoDB.DateJoined;
                    data.Department = ceoDB.Department;
                    data.Password = ceoDB.Password;
                    await dataAccesser.SaveChangesAsync();
                }
            }
        }
    


}
