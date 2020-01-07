using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web1.Exts;
using web1.Models;

namespace web1.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Book
        public async Task<ActionResult> Index(int page = 1)
        {
           // var Books = await context.Books.ToListAsync();
            var Books = await context.Books.OrderBy(b=>b.BookID).GetPaged(page, 2);
            
            return View(Books);
        }

        // GET: Book/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var book = await context.Books.Where(b => b.BookID.Equals(id)).FirstOrDefaultAsync();

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public async Task<ActionResult> Create(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            Book b = new Book
            {
                BookTitle = model.BookTitle,
                BookContent = model.BookContent,
                BookMetaDescription = model.BookMetaDescription,
                BookMetaKeywords = model.BookMetaKeywords,
                BookMetaAuthor = model.BookMetaAuthor,
                BookCreatedTime = DateTime.Now,
                BookUpdatedTime = DateTime.Now,
                Id = User.Identity.GetUserId()

            };

            context.Books.Add(b);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var Book = await context.Books.Where(b=>b.BookID.Equals(id)).FirstOrDefaultAsync();

            return View(Book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var book = await context.Books.Where(b => b.BookID.Equals(id)).FirstOrDefaultAsync();


            book.BookTitle = model.BookTitle;
            book.BookContent = model.BookContent;
            book.BookMetaDescription = model.BookMetaDescription;
            book.BookMetaKeywords = model.BookMetaKeywords;
            book.BookMetaAuthor = model.BookMetaAuthor;             
            book.BookUpdatedTime = DateTime.Now;         

            
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var book = await context.Books.Where(b => b.BookID.Equals(id)).FirstOrDefaultAsync();

            if (book != null)
            {
                return View(book);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var book = await context.Books.Where(b => b.BookID.Equals(id)).FirstOrDefaultAsync();

            if (book != null) {

                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
            

            return RedirectToAction("Index");
        }
    }
}
