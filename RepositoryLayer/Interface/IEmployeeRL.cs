using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public bool DeleteEmployee(int EmployeeId);

        public UpdateEmployeeModel UpdateEmployee(UpdateEmployeeModel updateEmployee);
        public List<EmployeeModel> GetAllEmployee();

    }
}
