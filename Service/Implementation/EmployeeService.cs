using CommonModel.DbModel;
using CommonModel.ViewModel;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Generators;
using Repository.Implementation;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>The employee repository</summary>
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>Initializes a new instance of the <see cref="EmployeeService" /> class.</summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>Gets all data.</summary>
        /// <param name="emp"></param>
        public void AddUser(EmpLoginViewModel emp)
        {

            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(emp.Password);
                var empViewModel = new EmpLogin()
                {
                    Email = emp.Email,
                    Password = hashedPassword
                };
                _employeeRepository.AddUser(empViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>Adds the employee.</summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployee(EmployeeDetailsViewModel employee)
        {
            try
            {
                var empViewModel = new EmployeeDetails()
                {
                    Name = employee.Name,
                    DesignationId = employee.DesignationId,
                    ProfilePicture = employee.ProfilePicture,
                    Salary = employee.Salary,
                    Date_Of_Birth = employee.Date_Of_Birth,
                    Email = employee.Email,
                    Address = employee.Address
                };
                _employeeRepository.AddEmployee(empViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Gets all data.</summary>
        public IList<EmployeeDetailsViewModel> GetAllData()
        {
            try
            {
                var employeeAll = _employeeRepository.GetAllData();
                List<EmployeeDetailsViewModel> employeedata = new List<EmployeeDetailsViewModel>();

                foreach (var Item in employeeAll)
                {
                    employeedata.Add(new EmployeeDetailsViewModel()
                    {
                        Id = Item.Id,
                        Name = Item.Name,
                        Designation = Item.Designation,
                        DesignationId = Item.DesignationId,
                        ProfilePicture = Item.ProfilePicture,
                        Salary = Item.Salary,
                        Date_Of_Birth = Item.Date_Of_Birth,
                        Email = Item.Email,
                        Address = Item.Address
                    });
                }
                return employeedata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Gets the employee details.</summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Employee not found!</exception>
        public EmployeeDetailsViewModel GetEmployeeDetails(int id)
        {
            var exitEmployee = _employeeRepository.GetEmployeeById(id);

            if (exitEmployee != null)
            {
                EmployeeDetailsViewModel employeeData = new EmployeeDetailsViewModel();
                employeeData.Name = exitEmployee.Name;
                employeeData.DesignationId = exitEmployee.DesignationId;
                employeeData.ProfilePicture = exitEmployee.ProfilePicture;
                employeeData.Salary = exitEmployee.Salary;
                employeeData.Date_Of_Birth = exitEmployee.Date_Of_Birth;
                employeeData.Email = exitEmployee.Email;
                employeeData.Address = exitEmployee.Address;

                return employeeData;
            }
            else
            {
                throw new Exception("Employee not found!");
            }
        }

        /// <summary>Edits the employee.</summary>
        /// <param name="employee">The employee.</param>
        public void EditEmployee(EmployeeDetailsViewModel employee)
        {
            try
            {
                EmployeeDetails employeedata = new EmployeeDetails();
                {
                    employeedata.Id = employee.Id;
                    employeedata.Name = employee.Name;
                    employeedata.DesignationId = employee.DesignationId;
                    employeedata.ProfilePicture = employee.ProfilePicture;
                    employeedata.Salary = employee.Salary;
                    employeedata.Date_Of_Birth = employee.Date_Of_Birth;
                    employeedata.Email = employee.Email;
                    employeedata.Address = employee.Address;
                };
                _employeeRepository.EditEmployee(employeedata);
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
                {
                    _employeeRepository.DeleteEmployee(id);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Gets the designation data.</summary>
        public IList<EmployeeDesignationViewModel> GetDesignationData()
        {
            try
            {
                var employeedesignation = _employeeRepository.GetDesignation();
                List<EmployeeDesignationViewModel> employeedata = new List<EmployeeDesignationViewModel>();

                foreach (var Item in employeedesignation)
                {
                    employeedata.Add(new EmployeeDesignationViewModel()
                    {
                        Id = Item.Id,
                        Designation = Item.Designation,
                    });
                }
                return employeedata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GetEmpDetail(EmpLoginViewModel employee)
        {
            if (employee == null)
            {
                throw new Exception("Invalid email or password");
            }

            var empdetails = _employeeRepository.GetEmpDetails(employee.Email);

            if (empdetails != null && empdetails.Email == employee.Email && BCrypt.Net.BCrypt.Verify(employee.Password, empdetails.Password))
            {
                Console.WriteLine("Login Successful");
            }
            else
            {
                throw new Exception("Invalid email or password");
            }
        }
    }


}

