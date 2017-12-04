using NAA.Data;
using NAA.Data.BEANS;
using NAA.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace NAA.Controllers
{

    public class NAAAdminController : Controller
    {
        private NAAService naaService;

        public NAAAdminController()
        {
            naaService = new NAAService();
        }

        // GET: NAAAdmin
        [AllowAnonymous]
        public ActionResult AddProfile()
        {
            
            ApplicantProfile profile = new ApplicantProfile();
            profile.Email = User.Identity.Name;
            return View(profile);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddProfile(ApplicantProfile profile)
        {
            profile.UserId = User.Identity.GetUserId();
            naaService.AddProfile(profile);
            //return RedirectToAction("Login", new { Controller = "Account" });
            return RedirectToAction("ApplicantHome", new { Controller = "Home" });
        }

        [Authorize(Roles = "Applicant")]
        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            ApplicantProfile profile = naaService.GetProfile(id);
            return View(profile);
        }
        [Authorize(Roles = "Applicant")]
        [HttpPost]
        public ActionResult EditProfile(ApplicantProfile profile)
        {
            try
            {
                naaService.EditProfile(profile);
                return RedirectToAction("Profiles", new { Controller = "NAA"});
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Applicant")]
        [HttpGet]
        public ActionResult EditPersonalProfile()
        {
            ApplicantProfile profile = naaService.GetProfile(naaService.GetApplicantIdByUserId(User.Identity.GetUserId()));
            return View(profile);
        }
        [Authorize(Roles = "Applicant")]
        [HttpPost]
        public ActionResult EditPersonalProfile(ApplicantProfile profile)
        {
            profile.UserId = User.Identity.GetUserId();
            try
            {
                naaService.EditProfile(profile);
                return RedirectToAction("ApplicantHome", new { Controller = "Home" });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteProfile(int id)
        {
            ApplicantProfile profile = naaService.GetProfile(id);
            return View(profile);
        }

        [HttpPost]
        public ActionResult DeleteProfile(ApplicantProfile profile)
        {
            ApplicantProfile anotherProfile = naaService.GetProfile(profile.Id);
            naaService.DeleteProfile(anotherProfile);
            return RedirectToAction("Profiles", new { Controller = "NAA" });
            //return RedirectToAction("DebugPage", new { message = "DETAILS: "+temp, Controller = "Music" });
        }

        //[Authorize(Roles = "Applicant")]
        public ActionResult ApplyForCourse(int universityId, string course)
        {
            NAAWeb.Services.Service.NAAWebService naaWebService = new NAAWeb.Services.Service.NAAWebService();
            if(naaWebService.GetCoursesByUniversityId(universityId)==null)
            {
                return RedirectToAction("UnderConstruction", new {Controller = "NAAWebService" });
            }
            else
            {
                List<SelectListItem> listOfCourses = new List<SelectListItem>();
                IList<UniversityBEAN> theCourses = naaWebService.GetCoursesByUniversityId(universityId);
                foreach (var item in theCourses)
                {
                    listOfCourses.Add(
                        new SelectListItem()
                        {
                            Text = item.Name,
                            Value = item.Name
                        });
                }
                ViewBag.listOfCourses = listOfCourses;

                string uid = User.Identity.GetUserId();

                ApplicationBEAN newApplication = new ApplicationBEAN();
                newApplication.CourseName = course;
                newApplication.UniversityId = universityId;

                return View(newApplication);
            } 
        }
        //[Authorize(Roles = "Applicant")]
        [HttpPost]
        public ActionResult ApplyForCourse(ApplicationBEAN application)
        {
            application.ApplicantId = naaService.GetApplicantIdByUserId(User.Identity.GetUserId());
            naaService.AddApplication(application);
            return RedirectToAction("Applications", new { Controller = "NAA" });
        }

        [Authorize(Roles = "Applicant")]
        public ActionResult SetApplicationFirm(int applicationId)
        {
            naaService.SetApplicationFirm(applicationId);
            return RedirectToAction("Applications", new { Controller = "NAA" });
        }
       
        [Authorize(Roles = "Staff")]
        public ActionResult AddUniversity()
        {
            University newUniversity = new University();
            return View(newUniversity);
        }
        [Authorize(Roles = "Staff")]
        [HttpPost]
        public ActionResult AddUniversity(University newUniversity)
        {
            naaService.AddUniversity(newUniversity);
            return RedirectToAction("UniversityManager", new { Controller = "NAA" });
        }

    }
}