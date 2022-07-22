using BusinessLayer.Interface;
using DatabaseLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL EmployeeRL;

        public EmployeeBL(IEmployeeRL EmployeeRL)
        {
            this.EmployeeRL = EmployeeRL;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                return this.EmployeeRL.AddEmployee(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            try
            {
                return this.EmployeeRL.DeleteEmployee(EmployeeId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return this.EmployeeRL.GetAllEmployee();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UpdateEmployeeModel UpdateEmployee(UpdateEmployeeModel updateEmployee)
        {
            try
            {
                return this.EmployeeRL.UpdateEmployee(updateEmployee);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
