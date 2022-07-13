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
    }
}
