using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team2_LMS.DataAccesslayer;
using Team2_LMS.Models;
using Team2_LMS.Repository;

namespace Team2_LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CeoDetailsController : ControllerBase
    {
        private readonly ICeoRepo iceoRepo;

        public CeoDetailsController(ICeoRepo iceoRepo)
        {
            this.iceoRepo = iceoRepo;
        }
        [HttpGet]
        [Route("Allceo")]
        public async Task<IActionResult> displayall()
        {
            var ar = await iceoRepo.GetAllCeo();
            return Ok(ar);
        }
        [HttpGet]
        [Route("ShowSpecific")]
        public async Task<IActionResult> ShowSpecific(int CeoId)
        {
            var ar = await iceoRepo.SearchById(CeoId);
            return Ok(ar);
        }
        [HttpPost]
        [Route("AddCeo")]
        public async Task<int> AddnewCeo(CeoModel ceoModel)
        {
            var ar = await iceoRepo.AddNewCeo(ceoModel);
            return 1;
        }
        [HttpDelete]
        [Route("DeleteCeo/{CeoId?}")]
        public async Task<IActionResult> DeleteCeo(int? CeoId)
        {
            if (CeoId != null)
            {
                await iceoRepo.RemoveCeo(CeoId);
                return Ok();
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("UpdateCeo/{CeoId?}")]
        public async Task<IActionResult> UpdateCeo(int? CeoId, CeoDB ceoDB)
        {
            if (CeoId != null)
            {
                await iceoRepo.UpdateCeo(CeoId, ceoDB);
                return Ok();
            }
            return NotFound();
        }
    }
}

