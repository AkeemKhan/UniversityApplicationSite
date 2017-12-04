using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NAA.Data;
using NAA.Services;
using NAA.Services.Service;


/// <summary>
/// Summary description for University
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class University : System.Web.Services.WebService {

    private NAAService naaService;
    public University () {
        naaService = new NAAService();
    }

    [WebMethod]
    public List<NAA.Data.Application> GetListOfApplicationsByUniId(int id)
    {
        return naaService.GetListOfApplications(id);
    }

    [WebMethod]
    public List<NAA.Data.Application> GetApplicationsByApplicant(int id)
    {
        return naaService.GetApplicationByApplicant(id);
    }

    [WebMethod]
    public void UpdateOffer(int applicationId, int universityId, string offer)
    {
        naaService.UpdateOffer(applicationId, universityId, offer);
    }

    [WebMethod]
    public List<NAA.Data.Application> GetApplicationByUniAndApplication(int applicantId, int universityId)
    {
        return naaService.GetApplicationByUniAndApplicant(applicantId, universityId);
    }

    [WebMethod]

    public List<NAA.Data.Application> GetApplicationsByStateOfOffer(int universityId, char stateOfOffer)
    {
        return naaService.GetApplicationsByStateOfOffer(universityId, stateOfOffer);
    }
    
}

/*
NAA exposes a web service that University will use to look up its applications. ---DONE----
NAA exposes a Web service for University to look up a student application.
NAA exposes a Web service for the University to update an application with an offer/decision.
*/