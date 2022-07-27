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
            return this.EmployeeRL.AddEmployee(employee);
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            return this.EmployeeRL.DeleteEmployee(EmployeeId);
        }
        public List<EmployeeModel> GetAllEmployee()
        {
            return this.EmployeeRL.GetAllEmployee();
        }
        public UpdateEmployeeModel UpdateEmployee(UpdateEmployeeModel updateEmployee)
        {

            return this.EmployeeRL.UpdateEmployee(updateEmployee);
        }

    }
}
