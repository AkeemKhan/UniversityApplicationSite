using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAAWeb.Services.IService
{
    interface INAAWebService
    {
        IList<SheffieldUniCourses.SheffieldUniCourses> GetCourses_SheffieldUni();
        IList<SheffieldHallamCourses.SHUWebService> GetCourses_SheffieldHallam();

    }
}
