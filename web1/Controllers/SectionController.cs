using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web1.Models;

namespace web1.Controllers
{
    public class SectionController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Section
        public async Task<ActionResult> Index()
        {
            var Sections = await context.Sections.ToListAsync();

            return View(Sections);
        }

        // GET: Section/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Section/Create
        public ActionResult Create(int id)
        {
            SectionViewModel Section = new SectionViewModel
            {                
                BookID = id                
            };
            return View(Section);
        }

        // POST: Section/Create
        [HttpPost]
        public async Task<ActionResult> Create(int id, SectionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Section Section = new Section
            {            
                SectionTitle = model.SectionTitle,
                SectionContent = model.SectionContent,
                SectionMetaDescription = model.SectionMetaDescription,
                SectionMetaKeywords = model.SectionMetaKeywords,
                SectionMetaAuthor= model.SectionMetaAuthor,
                SectionCreatedTime = DateTime.Now,
                SectionUpdatedTime = DateTime.Now,
                BookID = id,
                Id = User.Identity.GetUserId()
            };

            context.Sections.Add(Section);

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Section/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Section/Edit/5
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

        // GET: Section/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Section/Delete/5
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
