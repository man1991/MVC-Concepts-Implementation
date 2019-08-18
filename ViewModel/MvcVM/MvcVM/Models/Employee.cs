using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVM.Models
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Salary { get; set; }

    }
}