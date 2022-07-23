using BusinessLayer.Interface;
using DatabaseLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeRoleBL:IEmployeeRoleBL
    {
        private readonly IEmployeeRoleRL EmployeeRL;

        public EmployeeRoleBL(IEmployeeRoleRL EmployeeRL)
        {
            this.EmployeeRL = EmployeeRL;
        }
        public string Login(EmployeeLoginModel employeeLoginModel)
        {
            try
            {
                return this.EmployeeRL.Login(employeeLoginModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public EmployeeModel GetEmployeeDetail(int EmployeeId)
        {
            try
            {
                return this.EmployeeRL.GetEmployeeDetail(EmployeeId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
