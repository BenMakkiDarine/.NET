using EasyMission.SpecificService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        ServiceAccount userAccount = new ServiceAccount();
       
        public ActionResult Index()
        {
            string role=null;
            ViewData["Role"] = "";
            IEnumerable<string> roles = new List<string>();
               roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            foreach(var x in roles)
            {
                role = x;
            }

            if(role != null)
            {

                ViewData["Role"] = role;


            }
           
            return View();

            
        }
       

        public ActionResult About()
        {
            string role = null;
            ViewData["Role"] = "";
            IEnumerable<string> roles = new List<string>();
            roles = ((ClaimsIdentity)User.Identity).Claims
             .Where(c => c.Type == ClaimTypes.Role)
             .Select(c => c.Value);
            foreach (var x in roles)
            {
                role = x;
            }

            if (role != null)
            {

                ViewData["Role"] = role;


            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            string role = null;
            ViewData["Role"] = "";
            IEnumerable<string> roles = new List<string>();
            roles = ((ClaimsIdentity)User.Identity).Claims
             .Where(c => c.Type == ClaimTypes.Role)
             .Select(c => c.Value);
            foreach (var x in roles)
            {
                role = x;
            }

            if (role != null)
            {

                ViewData["Role"] = role;


            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}