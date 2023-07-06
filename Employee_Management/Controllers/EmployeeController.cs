using CommonModel.ViewModel;

using Service.Implementation;
using Employee_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.IO;
using Service.Interface;

namespace Employee_Management.Controllers
{
    public class EmployeeController : Controller
    {
        /// <summary>The employee service</summary>
        private readonly IEmployeeService _employeeService; // Use the interface instead of the concrete class

        /// <summary>Initializes a new instance of the <see cref="EmployeeController" /> class.</summary>
        /// <param name="employeeService">The employee service.</param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employee
        /// Indexes this instance.
        public ActionResult Index()
        {
            IList<EmployeeDetailsViewModel> employeelist = _employeeService.GetAllData();
            return View(employeelist);
        }

        /// <summary>Creates this instance.</summary>
        public ActionResult Create()
        {
            ViewBag.Designation = new SelectList(Designation(), "Id", "Designation");
            return View();
        }

        /// <summary>Adds the employee.</summary>
        /// <param name="employee">The employee.</param>
        [HttpPost] 
        public ActionResult AddEmployee(EmployeeDetailsViewModel employee)
        {
            try
            {
                if (employee.ProfilePictures.FileName != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(employee.ProfilePictures.FileName) + DateTime.Now.ToString("ddMMyyyyhhmmssfff") + Path.GetExtension(employee.ProfilePictures.FileName);
                    string path = Server.MapPath("~/Image/");
                    employee.ProfilePictures.SaveAs(path + filename);
                    employee.ProfilePicture = filename;
                }
                _employeeService.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Edits the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public ActionResult Edit(int id)
        {
            EmployeeDetailsViewModel emp = _employeeService.GetEmployeeDetails(id);
            ViewBag.Designation = new SelectList(Designation(), "Id", "Designation");
            return View(emp);
        }

        /// <summary>Edits the emp details.</summary>
        /// <param name="employee">The employee.</param>
        [HttpPost]
        public ActionResult EditEmpDetails(EmployeeDetailsViewModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (employee.ProfilePictures != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(employee.ProfilePictures.FileName) + DateTime.Now.ToString("ddMMyyyyhhmmssfff") + Path.GetExtension(employee.ProfilePictures.FileName);
                        string path = Server.MapPath("~/Image/");
                        employee.ProfilePictures.SaveAs(path + filename);
                        employee.ProfilePicture = filename;
                    }
                    _employeeService.EditEmployee(employee);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public ActionResult Delete(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                TempData["Success"] = "Employee Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>Designations this instance.</summary>
        [HttpGet]
        public IList<EmployeeDesignationViewModel> Designation()
        {
            return _employeeService.GetDesignationData();
        }
    }
}

