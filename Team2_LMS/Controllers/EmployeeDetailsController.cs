using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
        [Route("ShowSpecific/{EmployeeId?}")]
        public async Task<IActionResult> ShowSpecific(int EmployeeId)
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
        [Route("DeleteEmployee/{EmployeeId?}")]
        public async Task<IActionResult> DeleteEmployee(int? EmployeeId)
        {
            if (EmployeeId != null)
            {
                await iemployeeRepo.RemoveEmp(EmployeeId);
                return Ok();
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("UpdateEmployee/{EmployeeId?}")]
        public async Task<IActionResult> UpdateEmployee(int? EmployeeId, EmployeeDB employeeDB)
        {
            if (EmployeeId != null)
            {
                await iemployeeRepo.UpdateEmp(EmployeeId, employeeDB);
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        [Route("Login/{E_Mail}/{Password}")]
        public async Task<IActionResult> Loging(string? E_Mail, string? Password)
        {
            var add = await iemployeeRepo.Login(E_Mail, Password);
            if (add != null)
            {
                return Ok(add);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public  Task<ManagerDb> getname(int ManagerId)
        {
            var ar = iemployeeRepo.GetName(ManagerId);
            return ar;
        }
        ///below is the code for direct sql
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"
        //                    select * from
        //                    dbo.<tablename>
        //                    ";
        //    DataTable table = new DataTable();

        //    string sqlDataSource = "server=Maverick-VM-4;Database=testT2;uid=sa;pwd=Password123";
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
               
        //            using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //            {
        //                myReader = myCommand.ExecuteReader();
        //                table.Load(myReader);
        //                myReader.Close();
                   
        //        }
        //        return new JsonResult(table);
        //    }
        //}
        
    }
}
