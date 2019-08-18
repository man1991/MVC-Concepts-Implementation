using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVM.Models
{
    public class EmployeeVM
    {
        public Employee emp { get; set; }
        public User user { get; set; }

        public EmployeeVM(Employee e1, User u2)
        {
            emp = e1;
            user = u2;
        }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - emp.DateOfBirth.Year;
                if (emp.DateOfBirth > DateTime.Now.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public string SalaryColor
        {
            get
            {
                if (emp.Salary > 20000)
                {
                    return "red";
                }
                else
                {
                    return "green";
                }
            }
        }
    }
}