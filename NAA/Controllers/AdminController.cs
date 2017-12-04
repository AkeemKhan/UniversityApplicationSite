using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NAA.Models;

namespace Forest.Controllers
{
    public class AdminController : Controller
    {
        private NAA.Models.ApplicationDbContext _context;
        public AdminController()
        {
            _context = new NAA.Models.ApplicationDbContext();
        }

        [Authorize(Roles="Admin" )]
        public ActionResult GetUsers()
        {
            return View(_context.Users.ToList());
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    {
                        Name = collection["RoleName"]
                    });
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user =
                _context.Users.Where
                (u => u.UserName.Equals(UserName,
                    StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);

            // prepopulat roles for the view dropdown
            var roleList = _context.Roles.OrderBy
                (r => r.Name).ToList().Select
                (rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;
            // populate users for the view dropdown
            var userList = _context.Users.OrderBy
                (u => u.UserName).ToList().Select
                (uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View("ManageUserRoles");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult GetRolesForUser()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRolesForUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user =
                    _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesForUserConfirmed");
        }
    }
}