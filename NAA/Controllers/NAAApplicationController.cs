using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;
using NAA.Services;
using NAA.Services.Service;

namespace NAA.Controllers
{
    public class NAAApplicationController : Controller
    {
        private NAAService naaService;
        public NAAApplicationController()
        {
            naaService = new NAAService();
        }

        //http://localhost:2797/NAAWebService/DisplayUniversityCourses/1
        //public ActionResult ApplyForCourse(int universityId, string course)
        //{
        //    Application newApplicion = new Application();
        //    if(!String.IsNullOrEmpty(course))
        //    {
        //        newApplicion.CourseName = course;
        //    }

        //    //universityId = item.University, course = item.Name, 
        //    //int universityId, string course
            
        //    newApplicion.UniversityId = universityId;
        //    return View(newApplicion);
        //}

        [HttpPost]
        public ActionResult ApplyForCourse(Application application)
        {
            //naaService.AddApplication(application);
            return RedirectToAction("Profiles", new { Controller = "NAA" });
        }

        // GET: Application
        public ActionResult DisplayUniversities()
        {
            return View(naaService.DisplayUniversities());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}