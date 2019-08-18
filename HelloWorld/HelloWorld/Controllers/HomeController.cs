using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        //Condition 1: TempData will be persisted for next request if value is not read in .cshtml
        //Condition 2: TempData will not persist for next request if value is read in .cshtml
        //Condition 3: If you read using "TempData" and then call "Keep" method data will persist for next request if value is 
        //read in .cshtml and Keep is used
        //Condition 4: If you read using "TempData" by using "Peek" method data will persist for next request if value is 
        //read in .cshtml and Peek is used
        public ActionResult SomePage()
        {
            TempData["t1"] = "test";
            return View();
        }
        // GET: Home
        //public ActionResult Index()
        //{
        //    Session["MyTimeSession"] = DateTime.Now.ToString();
        //    TempData["MyTimeTemp"] = DateTime.Now.ToString();
        //    ViewBag.MyTime = DateTime.Now.ToString();
        //    return RedirectToAction("GotoHome", "Home");
        //    //return View();
        //}
        //public ActionResult GotoHome()
        //{
        //    ViewData["MyTime"] = DateTime.Now.ToString();
        //    ViewBag.MyTime = DateTime.Now.ToString();
        //    return View("MyHomePage");
        //}
        //If Action name is same as View name we dont need to put the name of View in return statement.
        //public ActionResult GotoHome()
        //{
        //    return View();
        //}
    }
}