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
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeRepo iemployeeRepo;

        public EmployeeDetailsController(IEmployeeRepo iemployeeRepo)
        {
            this.iemployeeRepo = iemployeeRepo;
        }
        [HttpGet]
        [Route("Allemp")]
        public async Task<IActionResult> displayall()
        {
            var ar = await iemployeeRepo.GetAllEmployee();
            return Ok(ar);
        }
        [HttpGet]
        [Route("ShowSpecific")]
        public async Task<IActionResult> ShowSpecific( int EmployeeId)
        {
            var ar = await iemployeeRepo.SearchById(EmployeeId);
            return Ok(ar);
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<int> AddnewEmployee(EmployeeModel employeeModel)
        {
            var ar = await iemployeeRepo.AddNewEmp(employeeModel);
            return 1;
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int? EmployeeId)
        {
            if(EmployeeId!=null)
            {
                await iemployeeRepo.RemoveEmp(EmployeeId);
                return Ok();
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int? EmployeeId,EmployeeDB employeeDB)
        {
            if(EmployeeId!=null)
            {
                await iemployeeRepo.UpdateEmp(EmployeeId,employeeDB);
                return Ok();
            }
            return NotFound();
        }
    }
}
