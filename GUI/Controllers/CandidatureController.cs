using EasyMission.Domaine;
using EasyMission.SpecificService;
using GUI.Models;
using Microsoft.AspNet.Identity;
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
    public class CandidatureController : Controller
    {
        ServiceCandidature cand = new ServiceCandidature();
        // GET: Candidature
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
            IEnumerable<candidature> getCan = cand.GetAll().Where(x => x.offre.aspnetuser.Id.Equals(User.Identity.GetUserId())).ToList();
            return View(getCan);
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
            Dictionary<String, int> zzzz = cand.StatCandidature();
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

        public ActionResult Approuvez(int id)
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
            candidature can = cand.GetById(id);
            if (can.status.Equals("non"))
            {
                can.status = "oui";
            }
            else
            {
                can.status = "non";

            }
            cand.Update(can);
            cand.Commit();
            return RedirectToAction("Index");

        }
        // GET: Candidature/Details/5
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
        public ActionResult UserCandi()
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
            IEnumerable<candidature> candUser = cand.GetAll().Where(x => x.idUser.Equals(User.Identity.GetUserId()));
            return View(candUser);
        }

        // GET: Candidature/Create
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

        // POST: Candidature/Create
        [HttpPost]
        public ActionResult Create(candidature can)
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
            cand.Add(can);
            cand.Commit();

                return RedirectToAction("Index");
            
                
            
        }
      

        // GET: Candidature/Edit/5
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

            return View(cand.GetById(id));
        }

        // POST: Candidature/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,candidature c)
        {
            string role = null;
            ViewData["Role"] = "";
            IEnumerable<string> roles = new List<string>();
            roles = ((ClaimsIdentity)User.Identity).Claims
             .Where(x => x.Type == ClaimTypes.Role)
             .Select(x => x.Value);
            foreach (var x in roles)
            {
                role = x;
            }

            if (role != null)
            {

                ViewData["Role"] = role;


            }
            candidature c1 = new candidature();
            c1 = cand.GetById(id);
            c1.description = c.description;
            c1.cvPAth = c.cvPAth;
            c1.dateSubmit = DateTime.Now;
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Cvs/"), fileName);
                string x = fileName;
                c1.cvPAth = x;
                file.SaveAs(path);
            }
            cand.Update(c1);
            cand.Commit();
                return RedirectToAction("Index");
            
        }

        // GET: Candidature/Delete/5
        public ActionResult Delete(int id)
        {
            string role = null;
            ViewData["Role"] = "";
            IEnumerable<string> roles = new List<string>();
            roles = ((ClaimsIdentity)User.Identity).Claims
             .Where(xc => xc.Type == ClaimTypes.Role)
             .Select(xc => xc.Value);
            foreach (var x in roles)
            {
                role = x;
            }

            if (role != null)
            {

                ViewData["Role"] = role;


            }
            candidature c = new candidature();
            c = cand.GetById(id);
            cand.Delete(c);
            cand.Commit();
            return RedirectToAction("Index");
        }

        // POST: Candidature/Delete/5
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

        public ActionResult promotionCandidatures()
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
            return View(cand.getPromotionByOffer());

        }

        
        public ActionResult CandidatureAccepted()
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
        public ActionResult getCandidatureAccepted()
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
            string param1 = Request.Form["dateDebut"];
            string param2 = Request.Form["dateFin"];
            DateTime dateDebut = DateTime.Parse("2017-04-29 09:58:14");
            DateTime dateFin = DateTime.Parse("2017-06-28 09:58:14");


            return View(cand.getCandidatureAccepted(dateDebut,dateFin));

        }





    }
}
