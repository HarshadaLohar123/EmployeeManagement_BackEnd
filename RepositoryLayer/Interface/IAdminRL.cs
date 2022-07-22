using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public AdminLoginModel Adminlogin(AdminResponse adminResponse);

    }
}
