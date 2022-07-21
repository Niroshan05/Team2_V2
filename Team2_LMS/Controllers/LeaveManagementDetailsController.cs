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
    public class LeaveManagementDetailsController : ControllerBase
    {
        private readonly ILeaveManagementRepo ileavemanagementRepo;

        public LeaveManagementDetailsController(ILeaveManagementRepo ileavemanagementRepo )
        {
            this.ileavemanagementRepo = ileavemanagementRepo;
        }
        [HttpGet]
        [Route("Allleave")]
        public async Task<IActionResult> displayall()
        {
            var ar = await ileavemanagementRepo.GetAllLeave();
            return Ok(ar);
        }
        [HttpGet]
        [Route("ShowSpecific/{LeaveId?}")]
        public async Task<IActionResult> ShowSpecific(int LeaveId)
        {
            var ar = await ileavemanagementRepo.SearchById(LeaveId);
            return Ok(ar);
        }
        [HttpPost]
        [Route("AddLeave")]
        public async Task<int> AddnewLeave(LeaveManagementModel leavemanagementModel)
        {
            var ar = await ileavemanagementRepo.AddNewLeave(leavemanagementModel);
            return 1;
        }
        [HttpDelete]
        [Route("DeleteLeave/{LeaveId?}")]
        public async Task<IActionResult> DeleteLeave(int? LeaveId)
        {
            if (LeaveId != null)
            {
                await ileavemanagementRepo.RemoveLeave(LeaveId);
                return Ok();
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("UpdateLeave/{LeaveId?}")]
        public async Task<IActionResult> UpdateLeave(int? LeaveId, LeaveManagementDB leavemanagementDb)
        {
            if (LeaveId != null)
            {
                await ileavemanagementRepo.UpdateLeave(LeaveId, leavemanagementDb);
                return Ok();
            }
            return NotFound();
        }
    }
}
