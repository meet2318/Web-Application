using CommonModel.DbModel;
using CommonModel.ViewModel;
using Dapper;
using Org.BouncyCastle.Crypto.Generators;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {

        /// <summary>Adds the user.</summary>
        /// <param name="emp">The emp.</param>
        public List<EmpLogin> AddUser(EmpLogin emp)
        {
            try
            {
                var parameter = new DynamicParameters();
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    parameter.Add("@Email", emp.Email);
                    parameter.Add("@Password", emp.Password);
                    return connection.Query<EmpLogin>("EmpLogin_AddNewUser", parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Adds the employee.</summary>
        /// <param name="employee">The employee.</param>
        public List<EmployeeDetails> AddEmployee(EmployeeDetails employee)
        {
            try
            {
                var parameter = new DynamicParameters();
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    parameter.Add("@Name", employee.Name);
                    parameter.Add("@DesignationId", employee.DesignationId);
                    parameter.Add("@ProfilePicture", employee.ProfilePicture);
                    parameter.Add("@Salary", employee.Salary);
                    parameter.Add("@Date_Of_Birth", employee.Date_Of_Birth);
                    parameter.Add("@Email", employee.Email);
                    parameter.Add("@Address", employee.Address);
                    return connection.Query<EmployeeDetails>("Employee-Details_AddNewEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Gets all data.</summary>
        public IList<EmployeeDetails> GetAllData()
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    return connection.Query<EmployeeDetails>("Employee-Details_GetAllEmployees_Details", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Edits the employee.</summary>
        /// <param name="employee">The employee.</param>
        public void EditEmployee(EmployeeDetails employee)
        {
            try
            {
                var parameter = new DynamicParameters();
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    parameter.Add("@Id", employee.Id);
                    parameter.Add("@Name", employee.Name);
                    parameter.Add("@DesignationId", employee.DesignationId);
                    parameter.Add("@ProfilePicture", employee.ProfilePicture);
                    parameter.Add("@Salary", employee.Salary);
                    parameter.Add("@Date_Of_Birth", employee.Date_Of_Birth);
                    parameter.Add("@Email", employee.Email);
                    parameter.Add("@Address", employee.Address);
                    connection.Query<EmployeeDetails>("Employee_Details_UpdateEmpDetails", parameter, commandType: CommandType.StoredProcedure);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Gets the employee by identifier.</summary>
        /// <param name="id">The identifier.</param>
        public EmployeeDetails GetEmployeeById(int id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    string query = "SELECT * FROM Employee_Details WHERE Id = @Id";
                    return connection.QueryFirstOrDefault<EmployeeDetails>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEmployee(int id)
        {
            try
            {
                var parameter = new DynamicParameters();
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    parameter.Add("@Id", id);
                    connection.Execute("Employee-Details_DeleteEmpById", parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Gets the designation.</summary>
        public IList<EmployeeDesignation> GetDesignation()
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                return connection.Query<EmployeeDesignation>("Employee-Designation_GetEmployeesDetails", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public EmpLogin GetEmpDetails(string Email)
        {
            try
            {
                var parameter = new DynamicParameters();
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    parameter.Add("@Email", Email);
                    return connection.QueryFirstOrDefault<EmpLogin>("EmpLogin_Getall", parameter,commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}