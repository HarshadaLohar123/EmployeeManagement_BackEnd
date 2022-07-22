using BusinessLayer.Interface;
using DatabaseLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.Controllers
{
    [ApiController]  
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminBL adminBL;

        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }
        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(AdminResponse adminResponse)
        {
            try
            {
                var result = this.adminBL.Adminlogin(adminResponse);
                if (result != null)
                    return this.Ok(new { success = true, message = " Admin Login Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Login Failed", data = result });
            }
            catch (Exception)
            {
                return this.BadRequest(new { success = false, message = "Login Failed" });
            }
        }

    }
}
