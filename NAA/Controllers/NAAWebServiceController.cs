using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    public class NAAWebServiceController : Controller
    {
        private NAAWeb.Services.Service.NAAWebService nAAWebServices;
        
        public NAAWebServiceController()
        {
            nAAWebServices = new NAAWeb.Services.Service.NAAWebService();
        }

        public ActionResult DisplaySheffieldUniCourses()
        {
            return View(nAAWebServices.GetCourses_SheffieldUni());
        }

        public ActionResult DisplaySheffieldHallamCourses()
        {
            return View(nAAWebServices.GetCourses_SheffieldHallam());
        }

        [AllowAnonymous]
        public ActionResult DisplayUniversityCourses(int id)
        {
            //Using the id from University Table, return a view based on the id that corrosponds to University
            //If not available, returns to Under construction page
            switch (id)
            {
                case 1:
                    return View(nAAWebServices.GetCourses_SheffieldUni());
                case 2:
                    return View(nAAWebServices.GetCourses_SheffieldHallam());
                default:
                    return RedirectToAction("UnderConstruction");
            }

        }
        [AllowAnonymous]
        public ActionResult UnderConstruction()
        {
            return View();
        }

        public ActionResult ShuTest()
        {
            return View(nAAWebServices.shucoursestest());
        }

        // GET: NAAWebService
        public ActionResult Index()
        {
            return View();
        }
    }
}