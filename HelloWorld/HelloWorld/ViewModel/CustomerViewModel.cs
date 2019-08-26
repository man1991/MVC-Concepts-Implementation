using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;//As CustomerViewModel internally uses Model

namespace HelloWorld.ViewModel
{
    /// <summary>
    /// This CustomerViewModel class represents Customer data as well as list of customer.
    /// CustomerViewModel class has two models : 1) customer 2) List of customers
    /// customer will be attached two text boxes: Customer Name and Customer Code
    /// customers will help to represent data into the grid i.e. list of customers
    /// </summary>
    public class CustomerViewModel
    {
        //Customer represent customer object
        public Customer customer { get; set; }

        //customers represents List of customers objects
        public List<Customer> customers { get; set; }
    }
}