using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMission.WebApp.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Profiles()
        {
            return View("Profiles");
        }

        // GET: Personel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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

        // GET: Personel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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

        // GET: Personel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
