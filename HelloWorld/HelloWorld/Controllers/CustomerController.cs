using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using HelloWorld.DAL;
using HelloWorld.ViewModel;//refernce view model class

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
            //view model object
            CustomerViewModel customerViewModel = new CustomerViewModel();

            //for first time user comes to EnterCustomer screen just bind it to empty customer object
            //customer object is for single object which will bind with textboxes
            //customers collection is a collection which will bind with a table
            customerViewModel.customer = new Customer();

            //using CustomerDAL filling customers Collection
            CustomerDAL objCustomer = new CustomerDAL();//to fetch data from database

            //populating data 
            List<Customer> customersCollection = objCustomer.Customers.ToList<Customer>();

            //passing customersCollection to represent data in grid: customers
            customerViewModel.customers = customersCollection;

            //passing this complete to EnterCustomer screen
            return View("EnterCustomer", customerViewModel);

            //to call EnterCustomer screen we cannot only pass Customer object we need to pass view model
            //return View("EnterCustomer", new Customer());
        }

        //EnterSearch() will invoke Search() customer screen
        public ActionResult EnterSearch()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.customers = new List<Customer>();
            return View("SearchCustomer", customerViewModel);
        }

        //Search() action will actually do a search
        public ActionResult SearchCustomer()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            CustomerDAL dalCustomer = new CustomerDAL();//to fetch data from database
            string str = Request.Form["txtCustomerName"].ToString();
            List<Customer> customersCollection =
                (from x in dalCustomer.Customers
                 where x.CustomerName == str
                 select x).ToList<Customer>();
            customerViewModel.customers = customersCollection;
            return View("SearchCustomer", customerViewModel);

        }
        //public ActionResult Submit([ModelBinder(typeof(CustomerBinder))]
        //    Customer obj)//In case name of textbox i.e. UI and property name of model class are same than we can dirctly put object like this and 
        //                                        //Request.Form is done directly by MVC framework itself

        //Customer object was polulating by itself. Automatic binding won't happen now so we have to map objects manually
        //and this because model structure is changed and as model structure is changed text box names are changed as
        //CustomerName has chnaged to Customer.CustomerName and CustomerCode has changed to Customer.CustomerCode
        //public ActionResult Submit(Customer obj)//Customer class represents middle layer
        public ActionResult Submit()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            Customer objCustomer = new Customer();

            //filling customer objects by proper textbox names
            //Proper way to do below is to use model binders
            objCustomer.CustomerName = Request.Form["Customer.CustomerName"];
            objCustomer.CustomerCode = Request.Form["Customer.CustomerCode"];

            if (ModelState.IsValid)
            {
                //insert the customer object to database using Entity framework DAL
                CustomerDAL customerDAL = new CustomerDAL();
                customerDAL.Customers.Add(objCustomer);//in-memory commit
                customerDAL.SaveChanges();//physical commit to database

                //return View("Customer", obj);
                //if Customer object -> objCustomer is valid and it's saved to database
                //than single view model customer has to be set new Customer object.
                customerViewModel.customer = new Customer();
            }
            else
            {
                //if customer object -> objCustomer is not valid we have to persist CustomerName and CustomerCode
                customerViewModel.customer = objCustomer;
            }
            //finally we need to load the customers collection
            CustomerDAL dalCustomer = new CustomerDAL();//to fetch data from database
            List<Customer> customersCollection = dalCustomer.Customers.ToList<Customer>();
            customerViewModel.customers = customersCollection;

            //As soon as Submit() is called -> EnterCustomer will be called irrespective of errors
            //EnterCustomer should not be binded with objCustomer which is a Customer object but it should be binded with
            //customerViewModel object
            //return View("EnterCustomer", obj);

            //passing customerViewModel object instead of objCustomer which is a Customer object
            return View("EnterCustomer", customerViewModel);
            //else
            //{
            //    return View("EnterCustomer", obj);//EnterCustomer is a UI
            //}

            //Customer obj = new Customer();
            //obj.CustomerCode = Request.Form["CustomerCode"];
            //obj.CustomerName = Request.Form["CustomerName"];

        }
    }
}