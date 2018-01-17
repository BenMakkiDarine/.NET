using EasyMission.Domaine;
using EasyMission.SpecificService;
using GUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ReclamationController : Controller
    {
        ServiceReclamation rec = new ServiceReclamation();
        ServiceAccount userAccount = new ServiceAccount();
        private ApplicationUserManager _userManager;

        // GET: Reclamation
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
            if (role.Equals("Admin"))
            {
                return View(rec.GetAll());

            }
            else
            {
                IEnumerable<reclamation> reclamationsGet = rec.GetAll().Where(x => x.user_idUser.Equals(User.Identity.GetUserId())).ToList();
                return View(reclamationsGet);

            }
        }


        public ActionResult Stat()
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
            //prepare array liste ro c#
            ArrayList Header = new ArrayList { "N", "Vote" };
            Dictionary<String, int> zzzz = rec.StatReclamation();
            ArrayList data = new ArrayList { Header };
            foreach (var s in zzzz)
            {
                ArrayList d = new ArrayList { s.Key, s.Value };
                data.Add(d);
            }

            string dataStr = JsonConvert.SerializeObject(data, Formatting.None);
            // store it in viewdata/ viewbag
            ViewBag.Data = new HtmlString(dataStr);
            return View();



        }

        // GET: Reclamation/Details/5
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
            IdentityResult result2 = await UserManager.SetLockoutEndDateAsync(id, DateTimeOffset.UtcNow.AddMinutes(1));


            if (result.Succeeded && result2.Succeeded)
            {
                return RedirectToAction("Index");

            }
            return null;


        }
        public async System.Threading.Tasks.Task<ActionResult> Bloquer30(string id)
        {
            IdentityResult result = await UserManager.SetLockoutEnabledAsync(id, true);
            IdentityResult result2 = await UserManager.SetLockoutEndDateAsync(id, DateTimeOffset.UtcNow.AddMinutes(30));


            if (result.Succeeded && result2.Succeeded)
            {
                return RedirectToAction("Index");

            }
            return null;


        }
        public async System.Threading.Tasks.Task<ActionResult> Bloquer60(string id)
        {
            IdentityResult result = await UserManager.SetLockoutEnabledAsync(id, true);
            IdentityResult result2 = await UserManager.SetLockoutEndDateAsync(id, DateTimeOffset.UtcNow.AddMinutes(60));


            if (result.Succeeded && result2.Succeeded)
            {
                return RedirectToAction("Index");

            }
            return null;


        }

        // GET: Reclamation/Create
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
            ViewBag.Category = new SelectList(userAccount.GetAll(), "Id", "Name");

            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(reclamation re)
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
            re.user_idUser = User.Identity.GetUserId();
            re.dateSubmit = DateTime.Now;
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Reclamations/"), fileName);
                string x = fileName;
                re.reclamationPath = x;
                file.SaveAs(path);
            }
            rec.Add(re);
            rec.Commit();

                return RedirectToAction("Index");
            
        }

        // GET: Reclamation/Edit/5
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
            return View(rec.GetById(id));
        }

        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, reclamation r)
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
            reclamation r1 = new reclamation();
            r1 = rec.GetById(id);
            r1.idReclamtion = id;
            r1.sujet = r.sujet;
            r1.dateSubmit = DateTime.Now;
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Reclamations/"), fileName);
                string x = fileName;
                r1.reclamationPath = x;
                file.SaveAs(path);
            }
            rec.Update(r1);
            rec.Commit();
            // TODO: Add update logic here

            return RedirectToAction("Index");

        }

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
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
            rec.Delete(rec.GetById(id));
            rec.Commit();
            return RedirectToAction("Index");
        }

        // POST: Reclamation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult getReclamationAdvancedAgent()
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

            string param1 = this.Request.QueryString["title"];
            string param2 = this.Request.QueryString["offre"];

            return View(rec.getReclamationBySpecialite(param1,param2));

           


        }

        public ActionResult getReclamationbyOffreDescription()
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
            string param1 = this.Request.QueryString["title"];

            return View(rec.getReclamationByTitle(param1));




        }



    }
}
