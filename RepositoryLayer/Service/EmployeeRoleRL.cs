using DatabaseLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRoleRL:IEmployeeRoleRL
    {
        private SqlConnection Connection;
        private readonly IConfiguration configuration;
        public EmployeeRoleRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        //Employee Login
        public string Login(EmployeeLoginModel employeeLoginModel)
        {
            this.Connection = new SqlConnection(this.configuration["ConnectionStrings:EmployeeManagement"]);
            try
            {

                SqlCommand command = new SqlCommand("EmployeeLogin", this.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Email", employeeLoginModel.Email);
                command.Parameters.AddWithValue("@Password", employeeLoginModel.Password);

                this.Connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    int EmployeeId = 0;
                    EmployeeLoginModel employee = new EmployeeLoginModel();
                    while (dataReader.Read())
                    {
                        employee.Email = Convert.ToString(dataReader["Email"]);
                        employee.Password = Convert.ToString(dataReader["Password"]);
                        EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]);
                    }

                    this.Connection.Close();
                    var Token = this.GenerateJWTToken(employee.Email, EmployeeId);
                    return Token;
                }
                else
                {
                    this.Connection.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Connection.Close();
            }
        }



        public string GenerateJWTToken(string Email, int EmployeeId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Role, "Employee"),
                     new Claim(ClaimTypes.Email, Email),
                new Claim("EmployeeId", EmployeeId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),

                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public EmployeeModel GetEmployeeDetail(int EmployeeId)
        {

            try
            {
                this.Connection = new SqlConnection(this.configuration["ConnectionStrings:EmployeeManagement"]);
                SqlCommand cmd = new SqlCommand("GetEmployeeByEmployeeId", this.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                this.Connection.Open();
                EmployeeModel employeeModel = new EmployeeModel();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeModel.FirstName = reader["FirstName"].ToString();
                        employeeModel.LastName = reader["LastName"].ToString();
                        employeeModel.Email = reader["Email"].ToString();
                        employeeModel.Password = reader["Password"].ToString();
                        employeeModel.EmpAddress = reader["EmpAddress"].ToString();
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.DateOfBirth = reader["DateOfBirth"].ToString();
                        employeeModel.Position = reader["Position"].ToString();
                        employeeModel.Salary = Convert.ToDecimal(reader["Salary"]);
                        employeeModel.PhoneNumber = reader["PhoneNumber"].ToString();

                    }

                    this.Connection.Close();
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Connection.Close();
            }
        }

    }
}
