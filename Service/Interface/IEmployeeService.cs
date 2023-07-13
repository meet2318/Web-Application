using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModel.ViewModel;

namespace Service.Interface
{
    public interface IEmployeeService
    {
        /// <summary>Adds the employee.</summary>
        /// <param name="employee">The employee.</param>
        void AddEmployee(EmployeeDetailsViewModel employee);
        /// <summary>Gets all data.</summary>
        /// <param name="emp"></param>
        void AddUser(EmpLoginViewModel emp);
        IList<EmployeeDetailsViewModel> GetAllData();
        /// <summary>Gets the employee details.</summary>
        /// <param name="id">The identifier.</param>
        EmployeeDetailsViewModel GetEmployeeDetails(int id);
        /// <summary>Edits the employee.</summary>
        /// <param name="employee">The employee.</param>
        void EditEmployee(EmployeeDetailsViewModel employee);
        /// <summary>Gets the designation data.</summary>
        IList<EmployeeDesignationViewModel> GetDesignationData();
        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        void DeleteEmployee(int id);

        void GetEmpDetail(EmpLoginViewModel employee);

    }
}
