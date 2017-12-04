using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;
using NAA.Services;
using NAA.Services.Service;
using Microsoft.AspNet.Identity;
using NAA.Data.BEANS;

namespace NAA.Controllers
{
    public class NAAController : Controller
    {
        // GET: NAA

        private NAAService naaService;

        public NAAController()
        {
            naaService = new NAAService();
        }

        [Authorize(Roles="Staff")]
        public ActionResult Profiles()
        {
            return View(naaService.GetProfiles());
        }

        [Authorize(Roles = "Staff")]
        public ActionResult Profile(int id)
        {
            return View(naaService.GetProfile(id));
        }

        [Authorize(Roles = "Applicant")]
        public ActionResult PersonalProfile()
        {
            return View(naaService.GetApplicantProfileByUserId(User.Identity.GetUserId()));
        }

        // GET: NAA/Details/5
        public ActionResult Details(int id)
        {
            return View(naaService.GetProfile(id));
        }

        // GET: NAA/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Applicant")]
        public ActionResult Applications()
        {
            int applicantId = naaService.GetApplicantIdByUserId(User.Identity.GetUserId());
            return View(naaService.GetListOfApplicationsByApplicantId(applicantId));
        }

        [Authorize(Roles = "Applicant")]
        public ActionResult Application(int applicationId)
        {
            ApplicationBEAN application = naaService.GetApplicationByApplicationId(applicationId);
            ViewBag.university = naaService.GetUniversityById(application.UniversityId);
            return View(application);
        }

        [Authorize(Roles = "Staff")]
        public ActionResult ReadOnlyApplications(int applicantId)
        {
            return View(naaService.GetListOfApplicationsByApplicantId(applicantId));
        }

        [Authorize(Roles = "Staff")]
        public ActionResult UniversityManager()
        {
            return View(naaService.DisplayUniversities());
        }
        // POST: NAA/Create
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

        // GET: NAA/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NAA/Edit/5
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

        // GET: NAA/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NAA/Delete/5
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
