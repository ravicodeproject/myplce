using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web1.Controllers
{
    public class BookImageController : Controller
    {
        // GET: BookImage
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookImage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookImage/Create
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

        // GET: BookImage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookImage/Edit/5
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

        // GET: BookImage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookImage/Delete/5
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
