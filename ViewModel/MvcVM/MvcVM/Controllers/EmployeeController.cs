using MvcVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcVM.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Show()
        {
            Employee e = GetEmployee();
            //ViewBag.CurrentUser = GetCurrentUser();
            User CurrentUser = GetCurrentUser();

            EmployeeVM evm = new EmployeeVM(e, CurrentUser);

            //return View(e);
            return View(evm);

        }
        private User GetCurrentUser()
        {
            User u = new User();
            u.UserName = "Questpond Subscriber";
            return u;
        }
        private Employee GetEmployee()
        {
            Employee e = new Employee();
            e.EmployeeName = "Sukesh Marla";
            e.Address = "Mumbai";
            e.DateOfBirth = new DateTime(1988, 10, 23);
            e.Salary = 15000;
            return e;
        }
    }
}