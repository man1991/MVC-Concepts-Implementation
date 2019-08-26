using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using HelloWorld.DAL;

namespace HelloWorld.Controllers
{
    //public class CustomerBinder : IModelBinder
    //{
    //    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    //    {
    //        HttpContextBase objContext = controllerContext.HttpContext;
    //        string custCode = objContext.Request.Form["txtCustomerCode"];
    //        string custName = objContext.Request.Form["txtCustomerName"];
    //        Customer obj = new Customer()
    //        {
    //            CustomerCode = custCode,
    //            CustomerName = custName
    //        };
    //        return obj;
    //    }
    //}
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult Load()
        {
            //Shortcut way of loading data inside object
            Customer obj = 
                new Customer
                {
                    CustomerCode = "1001",
                    CustomerName = "Manish"
                };
            return View("Customer",obj);
        }
        public ActionResult Enter()
        {
            return View("EnterCustomer", new Customer());
        }

        public ActionResult Submit(Customer obj)//Customer class represents middle layer
        //public ActionResult Submit([ModelBinder(typeof(CustomerBinder))]
        //    Customer obj)//In case name of textbox i.e. UI and property name of model class are same than we can dirctly put object like this and 
        //                                        //Request.Form is done directly by MVC framework itself
        {
            if(ModelState.IsValid)
            {
                //insert the customer object to database using Entity framework DAL
                CustomerDAL customerDAL = new CustomerDAL();
                customerDAL.Customers.Add(obj);//in-memory commit
                customerDAL.SaveChanges();//physical commit to database

                return View("Customer", obj);
            }
            else
            {
                return View("EnterCustomer", obj);//EnterCustomer is a UI
            }
            //Customer obj = new Customer();
            //obj.CustomerCode = Request.Form["CustomerCode"];
            //obj.CustomerName = Request.Form["CustomerName"];

        }
    }
}