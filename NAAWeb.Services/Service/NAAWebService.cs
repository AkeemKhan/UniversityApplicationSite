using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.BEANS;

namespace NAAWeb.Services.Service
{
    public class NAAWebService
    {
        private SheffieldUniCourses.SheffieldUniCourses sheffieldUniProxy;
        private SheffieldHallamCourses.SHUWebService sheffieldHallamProxy;

        public NAAWebService()
        {
            sheffieldUniProxy = new SheffieldUniCourses.SheffieldUniCourses();
            sheffieldHallamProxy = new SheffieldHallamCourses.SHUWebService();
        }

        //public IList<SheffieldUniCourses.Course> GetCourses_SheffieldUni()
        //{
        //    return sheffieldUniProxy.GetCoursesFullDetails();
        //}
        public IList<UniversityBEAN> GetCourses_SheffieldUni()
        {
            List<UniversityBEAN> uBeans = new List<UniversityBEAN>();
            SheffieldUniCourses.Course[] list = sheffieldUniProxy.GetCoursesFullDetails();
            foreach (SheffieldUniCourses.Course item in list)
            {
                UniversityBEAN temp = new UniversityBEAN();
                temp.Id = item.Id;
                temp.Description = item.Description;
                temp.EntryReq = item.EntryReq;
                temp.Name = item.Name;
                temp.University = 1;
                temp.UniversityName = "University of Sheffield";
                uBeans.Add(temp);
            }

            return uBeans;
        }

        public IList<UniversityBEAN> GetCourses_SheffieldHallam()
        {
            List<UniversityBEAN> uBeans = new List<UniversityBEAN>();
            SheffieldHallamCourses.CourseList[] list = sheffieldHallamProxy.GetAllCourses();
            foreach(SheffieldHallamCourses.CourseList item in list)
            {
                UniversityBEAN temp = new UniversityBEAN();
                temp.Id = item.CourseId;
                temp.Description = item.CourseDescription;
                temp.EntryReq = item.EntryCriteria;
                temp.Name = item.CourseName;
                temp.University = 2;
                temp.UniversityName = "Sheffield Hallam University";
                uBeans.Add(temp);
            }

            return uBeans;
        }

        public IList<UniversityBEAN> GetCoursesByUniversityId(int id)
        {
            switch (id)
            {
                case 1:
                    return GetCourses_SheffieldUni();
                case 2:
                    return GetCourses_SheffieldHallam();
                default:
                    return null;
            }
        }

        //TESTING-------------------------------
        public IList<SheffieldHallamCourses.CourseList> shucoursestest()
        {
            return sheffieldHallamProxy.GetAllCourses();
        }

        
    }
}
