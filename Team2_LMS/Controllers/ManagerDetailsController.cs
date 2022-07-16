using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.Models;
using Team2_LMS.Repository;

namespace Team2_LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerDetailsController : ControllerBase
    {
        private readonly IManagerRepo imanagerRepo;

        public ManagerDetailsController(IManagerRepo imanagerRepo)
        {
            this.imanagerRepo = imanagerRepo;
        }
        [HttpGet]
        [Route("Allmanager")]
        public async Task<IActionResult> displayall()
        {
            var ar = await imanagerRepo.GetAllManager();
            return Ok(ar);
        }
        [HttpGet]
        [Route("ShowSpecific")]
        public async Task<IActionResult> ShowSpecific(int ManagerId)
        {
            var ar = await imanagerRepo.SearchById(ManagerId);
            return Ok(ar);
        }
        [HttpPost]
        [Route("AddManager")]
        public async Task<int> AddnewManager(ManagerModel managerModel)
        {
            var ar = await imanagerRepo.AddNewManager(managerModel);
            return 1;
        }
        [HttpDelete]
        [Route("DeleteManager/{ManagerId?}")]
        public async Task<IActionResult> DeleteManager(int? ManagerId)
        {
            if (ManagerId != null)
            {
                await imanagerRepo.RemoveManager(ManagerId);
                return Ok();
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("UpdateManager/{ManagerId?}")]
        public async Task<IActionResult> UpdateManager(int? ManagerId, ManagerDb managerDb)
        {
            if (ManagerId != null)
            {
                await imanagerRepo.UpdateManager(ManagerId, managerDb);
                return Ok();
            }
            return NotFound();
        }
    }
}
