using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Net;
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
            // ViewBag.Message = RoleEnvironment.CurrentRoleInstance.Id +" " + RoleEnvironment.GetConfigurationSettingValue("MyString") ;
            var endpoint = RoleEnvironment.Roles["MyWorkerRole"].Instances[0].InstanceEndpoints["Endpoint1"];
            var address = string.Format("http://{0}", endpoint.IPEndpoint);
            WebClient client = new WebClient();
            ViewBag.Message = client.DownloadString(address);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}