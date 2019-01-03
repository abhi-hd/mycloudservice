using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace MyWebRole.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello Cloud !";
            return View();
        }

        public ActionResult About() 
        {
            ViewBag.Message = RoleEnvironment.CurrentRoleInstance.Id +" " + RoleEnvironment.GetConfigurationSettingValue("MyString") ;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}