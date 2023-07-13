using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModel.DbModel;
using CommonModel.ViewModel;

namespace Repository.Interface
{
    public interface IEmployeeRepository
    {
        /// <summary>Adds the employee.</summary>
        /// <param name="employee">The employee.</param>
        List<EmployeeDetails> AddEmployee(EmployeeDetails employee);

        /// <summary>Gets all data.</summary>
        IList<EmployeeDetails> GetAllData();

        EmpLogin GetEmpDetails(string Email);
        /// <summary>Gets the designation.</summary>
        IList<EmployeeDesignation> GetDesignation();

        /// <summary>Gets the employee by identifier.</summary>
        /// <param name="id">The identifier.</param>
        EmployeeDetails GetEmployeeById(int id);

        /// <summary>Edits the employee.</summary>
        /// <param name="employee">The employee.</param>
        void EditEmployee(EmployeeDetails employee);

        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        void DeleteEmployee(int id);

        /// <summary>Adds the user.</summary>
        /// <param name="emp">The emp.</param>
        List<EmpLogin> AddUser(EmpLogin emp);

        


    }
}
