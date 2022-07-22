using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Model
{
    public class UpdateEmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string EmpAddress { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }

    }
}
