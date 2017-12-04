using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NAA.Services.Service;
using NAA.Models;

namespace NAA.Controllers
{
    public class HomeController : Controller
    {
        private NAAService naaService;
        private ApplicationDbContext context;

        public HomeController()
        {
            naaService = new NAAService();
            context = new ApplicationDbContext();
        }

        public ActionResult HomePage()
        {
            //ViewBag.currentUrl = Request.Url.AbsoluteUri;
            return View();
        }

        public ActionResult UserHome()
        {       

            if (User.IsInRole("Admin"))
                return RedirectToAction("AdminHome", new { Controller = "Home" });
            else if (User.IsInRole("Staff"))
                return RedirectToAction("StaffHome", new { Controller = "Home" });
            else
            {
                return RedirectToAction("ApplicantHome", new { Controller = "Home" });
            }
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult StaffHome()
        {
            return View();
        }

        public ActionResult ApplicantHome()
        {
            ViewBag.userId = User.Identity.GetUserId();

            //Gets number of Applications by -
            //          -Getting ApplicantId by UserId
            //          --Use the ApplicantId to get count return as int
            ViewBag.NumberOfApplications = 
                naaService.GetNumberOfApplicationsByApplicantId(naaService.GetApplicantIdByUserId(User.Identity.GetUserId()));
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("HomePage");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}