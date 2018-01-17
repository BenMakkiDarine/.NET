using EasyMission.Domaine;
using EasyMission.SpecificService;
using GUI.Models;
using Microsoft.AspNet.Identity;
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
    public class ServiceController : Controller
    {

        ServiceService se = new ServiceService();
        ServiceOffre so = new ServiceOffre();
        // GET: Service
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
            return View(se.GetAll());
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
            Dictionary<String, int> zzzz = se.StatService();
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
        // GET: Service/Details/5
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
            return View(so.GetAll().Where(x=>x.idService.Equals(id)).ToList());
        }


        public ActionResult Comments(int id)
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
            feedBackComment cmnt = new feedBackComment();
            cmnt.feedbacks = se.getFeedBackbyId(id);
            return View(cmnt);
        }


        [HttpPost]
        public ActionResult Comments(int id,feedBackComment feed)
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
            feedBackComment cmnt = new feedBackComment();
            ServiceFeedBack sF = new ServiceFeedBack();
            feedback f = new feedback();
            f = feed.feedback;
            f.idUser = User.Identity.GetUserId();
            f.description = feed.feedback.description;
            f.idService = id;
            sF.Add(f);
            sF.Commit();
            return RedirectToAction("Index");
        }

        // GET: Service/Create
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

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(service ser)
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
            ser.user_idUser = User.Identity.GetUserId();
            se.Add(ser);
            se.Commit();
            return RedirectToAction("Index");

        }

        // GET: Service/Edit/5
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
            return View(se.GetById(id));
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,service s)
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
            service s1 = new service();
            s1 = se.GetById(id);
            s1.nomService = s.nomService;
            s1.categorieService = s.categorieService;
            s1.description = s.description;
            se.Update(s1);
            se.Commit();
            return RedirectToAction("Index");
        }

        // GET: Service/Delete/5
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
            se.Delete(se.GetById(id));
            se.Commit();
            return RedirectToAction("Index");
        }

        // POST: Service/Delete/5
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
        public ActionResult TacheAvance2()
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
        public ActionResult getHighDemandedServicesAffiche(string category)
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
            String param1 = this.Request.QueryString["category"];

            return View(se.getHighDemandedServices(param1));
        }
        public ActionResult getAgentByService(string category)
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
            String param1 = this.Request.QueryString["category"];

            return View(se.getAgentByService(param1));
        }

    }
}
