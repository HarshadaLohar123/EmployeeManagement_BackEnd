using BusinessLayer.Interface;
using DatabaseLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }
        IAdminRL adminRL;
        public AdminLoginModel Adminlogin(AdminResponse adminResponse)
        {
            return this.adminRL.Adminlogin(adminResponse);
        }
    }
}
