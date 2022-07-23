using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeRoleBL
    {
        //Employee Functionality
        public string Login(EmployeeLoginModel employeeLoginModel);
        public EmployeeModel GetEmployeeDetail(int EmployeeId);
    }
}
