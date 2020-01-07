using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class RoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Role
        [Authorize(Roles = "Manager")]
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    if (!isAdminUser())
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        [NonAction]
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.MSG = "";
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(RoleCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = model.Role;
                roleManager.Create(role);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MSG = "Role Already Exists";
                return View();
            }

            

        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddRole()
        {
            string usrnme = User.Identity.GetUserName();

            ViewBag.Roles = new SelectList(await context.Roles.Where(u => !u.Name.Contains("Admin")).ToListAsync(), "Name", "Name");
            ViewBag.UserNames = new SelectList(await context.Users.Where(us => !us.UserName.Equals(usrnme)).ToListAsync(), "UserName", "UserName");
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> AddRole(AddRoleViewModel model)
        {
            string usrnme = User.Identity.GetUserName();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = await context.Users.Select(tu => new { Id = tu.Id, UserName = tu.UserName }).Where(us => us.UserName == model.UserName).FirstOrDefaultAsync();

            var result1 = await UserManager.AddToRoleAsync(user.Id.ToString(), model.Role);

            var rls = await UserManager.GetRolesAsync(user.Id.ToString());

            ViewBag.Roles = new SelectList(await context.Roles.Where(u => !u.Name.Contains("Admin")).ToListAsync(), "Name", "Name");
            ViewBag.UserNames = new SelectList(await context.Users.Where(us => !us.UserName.Equals(usrnme)).ToListAsync(), "UserName", "UserName");

            return View();
        }
    }
}