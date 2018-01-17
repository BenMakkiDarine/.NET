using EasyMission.Domaine;
using EasyMission.SpecificService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Text;

namespace GUI.Controllers
{
    public class ListUsersController : Controller
    {

        ServiceCv s = new ServiceCv();
        ServiceAccount userAccount = new ServiceAccount();
        private ApplicationUserManager _userManager;

        ServiceAccount userService = new ServiceAccount();

        // GET: ListUsers
        public ActionResult Index()
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
            return View(s.GetAll());
        }
        public ActionResult Agent()
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
            return View(s.getUsersByRole("Agent"));
        }


        public ActionResult Client()
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
            return View(s.getUsersByRole("Client"));
        }
        // GET: ListUsers/Details/5
        public ActionResult Details(int id)
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
            return View();
        }

        // GET: ListUsers/Create
        public ActionResult Create()
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
            return View();
        }
        public ActionResult getDetails(string id)
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
            ViewData["Count"] = userService.countReclamation(id);
           
            return View(userService.getUser(id));
        }



        public ApplicationUserManager UserManager
        {

            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        

        public async System.Threading.Tasks.Task<ActionResult> Bloquer(string id)
        {
            IdentityResult result = await UserManager.SetLockoutEnabledAsync(id, true);
            IdentityResult result2 = await UserManager.SetLockoutEndDateAsync(id, DateTimeOffset.UtcNow.AddDays(1));


            if (result.Succeeded && result2.Succeeded)
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("ahmed.bettaieb@esprit.tn", "dayernaksa2012");

                MailMessage mm = new MailMessage(userService.getUser(id).Email, userService.getUser(id).Email, "Your Account Has Been Disabled ", "Dear " + userService.getUser(id).Name + " Your account has been disabled for 1 day");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return RedirectToAction("getDetails");

            }
            return null;


        }
        public async System.Threading.Tasks.Task<ActionResult> Bloquer30(string id)
        {
            IdentityResult result = await UserManager.SetLockoutEnabledAsync(id, true);
            IdentityResult result2 = await UserManager.SetLockoutEndDateAsync(id, DateTimeOffset.UtcNow.AddDays(30));


            if (result.Succeeded && result2.Succeeded)
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("ahmed.bettaieb@esprit.tn", "dayernaksa2012");

                MailMessage mm = new MailMessage("ahmed.bettaieb@esprit.tn", userService.getUser(id).Email, "Your Account Has Been Disabled ", "Dear " + userService.getUser(id).Email + " Your account has been disabled for 30 days ");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return RedirectToAction("getDetails");

            }
            return null;


        }






        // POST: ListUsers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListUsers/Edit/5
        public ActionResult Edit(int id)
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
            return View();
        }

        // POST: ListUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListUsers/Delete/5
        public ActionResult Delete(string id)
        {
            string role = null;
            ViewData["Role"] = "";
            IEnumerable<string> roles = new List<string>();
            roles = ((ClaimsIdentity)User.Identity).Claims
             .Where(ca => ca.Type == ClaimTypes.Role)
             .Select(ca => ca.Value);
            foreach (var x in roles)
            {
                role = x;
            }

            if (role != null)
            {

                ViewData["Role"] = role;


            }

            aspnetuser u = new aspnetuser();
            u = userService.getUser(id);
            u.cvs = null;
            cv c =s.Get(x => x.user_idUser.Equals(id));
            c.user_idUser = null;
            c.aspnetuser = null;
            s.Delete(c);
            s.Commit();
            userService.Delete(u);
            userService.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult FindResumeAll()
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
            string value = Request.Form["txtBox1"];

            return View(userAccount.getTalened());
        }

       
        public ActionResult FindResume()
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
            string param1 = this.Request.QueryString["specialite"];
            return View(userAccount.getTalentedUser(param1));
        }
        
        public ActionResult FindFreeAgents()
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
            String param1 = this.Request.QueryString["numberOfCandidatures"];
            int numberOfCandidatures = System.Convert.ToInt32(param1);


            string param2 = this.Request.QueryString["operation"];

            return View(userAccount.getFreeTalentedUser(numberOfCandidatures,param2));

        }

        [HttpPost]
        public ActionResult FindFreeAgentAdvanced()
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
            string param1 = Request.Form["numberOfCandidatures"];

            int numberOfCandidatures = System.Convert.ToInt32(param1);
            string param2 = Request.Form["operation"];
            
            return View(userAccount.getFreeTalentedUser(numberOfCandidatures, param2));


        }

        public ActionResult Chat()
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
            string room = this.Request.QueryString["room"];

            ViewData["userName"] = User.Identity.GetUserName();
            bool joined = false;
            ViewData["title"] = userAccount.getUser(User.Identity.GetUserId()).cvs.First().location;
            string currentUserId = User.Identity.GetUserId();
            List<aspnetuser> getUsers = userAccount.getUsersChat(room);
            foreach (var x in getUsers)
                {
                if(x.Id.Equals(currentUserId))
                {
                    joined = true;
                }
                

            }
            if(joined)
            {
                return View();
            }
            else
            {
                return null;
            }

        }





    }
}
