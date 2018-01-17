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
    public class ForumController : Controller
    {
        ServiceForum se = new ServiceForum();
        ServiceAccount userService = new ServiceAccount();
        ServiceCommentaire comnService = new ServiceCommentaire();

        // GET: Forum
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
            String id = User.Identity.GetUserId();
            ViewData["NomUser"] = se.getUserName(id).Name;

            return View(se.getForums());
        }

        // GET: Forum/Details/5
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
            if (se.GetById(id).idUser.Equals(User.Identity.GetUserId()))
            {
                ViewData["Delete"] = "oui";

            }
            else
            {
                ViewData["Delete"] = "non";

            }

            String idUser = User.Identity.GetUserId();
            ViewData["NomUser"] = se.getUserName(idUser).Name;
            Details de = new Details();
            de.Forum = se.GetById(id);
            ViewData["Count"] = comnService.GetAll().Where(x => x.idForum.Equals(id)).Count();
            de.commentaires = comnService.GetAll().Where(x => x.idForum.Equals(id)); 
            return View(de);
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
            ArrayList Header = new ArrayList { "N", "Commentaire" };
            Dictionary<String, int> zzzz = comnService.StatCommentaire();
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


        [HttpPost]
        public ActionResult Details(int id,Details de)
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
            Details d = new Models.Details();
           
            commentaire c = new commentaire();
            c = de.Commentaire;
            c.idUser = User.Identity.GetUserId();
            c.idForum = id;
            comnService.Add(c);
            comnService.Commit();
            
            return RedirectToAction("Index");

        }

        // GET: Forum/Create
        public ActionResult Create()
        {string role = null;
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

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(forum f)
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

            f.idUser = User.Identity.GetUserId();
            f.DateSubmit = DateTime.Now;
            ServiceForum s = new ServiceForum();
            s.Add(f);
            s.Commit();

            return RedirectToAction("Index");

        }

        // GET: Forum/Edit/5
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

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, forum f)
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

            forum f1 = new forum();
            f1 = se.GetById(id);
            f1.nomForum = f.nomForum;
            f1.sujets = f.sujets;
            f1.DateSubmit = f.DateSubmit;
            f1.description = f.description;
            se.Update(f1);
            se.Commit();
            return RedirectToAction("Index");

        }

        // GET: Forum/Delete/5
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
        public ActionResult getTask1Affiche()
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
            String param1 = this.Request.QueryString["nomService"];
            Details de = new Details();
            de.commentaires = se.getTask1(param1);
            return View(de);

        }

    }
}
