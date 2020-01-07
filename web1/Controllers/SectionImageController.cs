using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web1.Controllers
{
    public class SectionImageController : Controller
    {
        // GET: SectionImage
        public ActionResult Index()
        {
            return View();
        }

        // GET: SectionImage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SectionImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionImage/Create
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

        // GET: SectionImage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SectionImage/Edit/5
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

        // GET: SectionImage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SectionImage/Delete/5
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
