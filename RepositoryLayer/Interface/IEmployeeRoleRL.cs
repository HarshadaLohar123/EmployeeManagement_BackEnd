using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRoleRL
    {
        //Employee Functionality
        public string Login(EmployeeLoginModel employeeLoginModel);
        public EmployeeModel GetEmployeeDetail(int EmployeeId);
    }
}
