using BusinessLayer.Interface;
using DatabaseLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        [Authorize(Roles =Role.Admin)]
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            try
            {
                EmployeeModel userData = this.employeeBL.AddEmployee(employee);
                if (userData != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Registered Sucessfully", Response = userData });
                }
                return this.Ok(new { Success = true, message = "Sorry! Employee Already Exists" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("DeleteEmployee/{EmployeeId}")]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            try
            {
                if (this.employeeBL.DeleteEmployee(EmployeeId))
                {
                    return this.Ok(new { Success = true, message = "Employee Deleted Sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Sorry! please Enter Valid Employee Id" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost("UpdateEmployee")]
        public IActionResult UpdateEmployee(UpdateEmployeeModel updateEmployee)
        {
            try
            {
                UpdateEmployeeModel userData = this.employeeBL.UpdateEmployee(updateEmployee);
                if (userData != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Updated Sucessfully", Response = userData });
                }
                return this.Ok(new { Success = false, message = "Sorry! Updated Failed" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var updatedEmployeeDetail = this.employeeBL.GetAllEmployee();
                if (updatedEmployeeDetail != null)
                {
                    return this.Ok(new { Success = true, message = "Employee Detail Fetched Sucessfully", Response = updatedEmployeeDetail });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Sorry! Wrong credentials" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
