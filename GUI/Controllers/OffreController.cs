using EasyMission.Domaine;
using EasyMission.SpecificService;
using GUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class OffreController : Controller
    {
        ServiceService su = new ServiceService();
        ServiceOffre so = new ServiceOffre();
        ServiceCandidature sC = new ServiceCandidature();
        // GET: Offre


        [HttpPost]
        public ActionResult Index(offre o)
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
            return View(so.getOfferByLocationFilter(o));
        }

        // GET: Offre/Details/5
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

            OffreModel offremodel = new OffreModel();
            offremodel.offre = so.GetById(id);

            return View(offremodel);
        }

        [HttpPost]
        public ActionResult Details(int id, OffreModel offremodel)
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

            candidature candid = new candidature();
            candid.description = offremodel.candidature.description;
            candid.idUser = User.Identity.GetUserId();
            candid.idOffre = id;
            candid.dateSubmit = DateTime.Now;
            candid.status = "non";
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Cvs/"), fileName);
                string x = fileName;
                candid.cvPAth = x;
                file.SaveAs(path);
            }

            sC.Add(candid);
            sC.Commit();
            return RedirectToAction("Index","Service");
        }

        // GET: Offre/Create
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

            ViewBag.Category = new SelectList(su.GetAll(), "idService" , "nomService" );
            return View();
        }

        // POST: Offre/Create
        [HttpPost]
        public ActionResult Create(offre off)
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

            off.idUser = User.Identity.GetUserId();
            so.Add(off);
            so.Commit();
                // TODO: Add insert logic here

                return RedirectToAction("Index","Service");
           
        }

        // GET: Offre/Edit/5
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

        // POST: Offre/Edit/5
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

                return RedirectToAction("Index","Service");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offre/Delete/5
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

            so.Delete(so.GetById(id));
            so.Commit();
            return RedirectToAction("Index","Service");
        }

        // POST: Offre/Delete/5
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
