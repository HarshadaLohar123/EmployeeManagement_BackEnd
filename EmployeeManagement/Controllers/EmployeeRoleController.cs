using BusinessLayer.Interface;
using DatabaseLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeRoleController : Controller
    {
        private readonly IEmployeeRoleBL employeeBL;
        public EmployeeRoleController(IEmployeeRoleBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        [HttpPost("EmployeeLogin")]
        public IActionResult EmployeeLogin(EmployeeLoginModel employeeLogin)
        {
            try
            {
                var result = this.employeeBL.Login(employeeLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Employee Login Successful", Token = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Sorry!!! Login Failed", Token = result });
                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = "Sorry!!! Login Failed,Please enter valid Email and password" });

            }
        }

        [Authorize(Roles = Role.Employee)]
        [HttpGet("GetEmployeeDetail")]
        public IActionResult GetEmployeeDetail()
        {
            int EmployeeId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "EmployeeId").Value);
            try
            {

                var employee = this.employeeBL.GetEmployeeDetail(EmployeeId);
                if (employee != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Detail Fetched Sucessfully", Response = employee });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Sorry! Please Enter Valid Employee Id" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
