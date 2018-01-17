using EasyMission.Domaine;
using EasyMission.SpecificService;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class PromotionController : Controller
    {
        ServiceService su = new ServiceService();
        ServiceOffre so = new ServiceOffre();
        ServiceCandidature sC = new ServiceCandidature();
        ServicePromotion prom = new ServicePromotion();
        // GET: Promotion
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
            return View(prom.getPromotions());
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
            Dictionary<String, int> zzzz = prom.StatPromotion();
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
        // GET: Promotion/Details/5
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

        // GET: Promotion/Create
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
            ViewBag.Category = new SelectList(su.GetAll(), "idService", "nomService");

            return View();
        }

        // POST: Promotion/Create
        [HttpPost]
        public ActionResult Create(promotion pro)
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
            prom.Add(pro);
            prom.Commit();
            return RedirectToAction("Index");
        }

        // GET: Promotion/Edit/5
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

            return View(prom.GetById(id));
        }

        // POST: Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, promotion p)
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

            promotion p1 = new promotion();
            p1 = prom.GetById(id);
            p1.dateDebut = p.dateDebut;
            p1.dateFin = p.dateFin;
            p1.description = p.description;
            prom.Update(p1);
            prom.Commit();
                return RedirectToAction("Index");
            
        }

        // GET: Promotion/Delete/5
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
            prom.Delete(prom.GetById(id));
            prom.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult TacheAvance1()
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
        public ActionResult getService(string category)
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
            String param1 = this.Request.QueryString["email"];

            return View(prom.getService(DateTime.Now,param1));
        }
        // POST: Promotion/Delete/5
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
    }
}
