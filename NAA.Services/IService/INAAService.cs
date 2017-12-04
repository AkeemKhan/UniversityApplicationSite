using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.BEANS;

namespace NAA.Services.IService
{
    interface INAAService
    {
        //IList<ApplicantProfile> GetProfiles();
        IList<ApplicantBEAN> GetProfiles();
        ApplicantProfile GetProfile(int id);
        void AddProfile(ApplicantProfile profile);
        void EditProfile(ApplicantProfile profile);
        void DeleteProfile(ApplicantProfile profile);
        IList<University> DisplayUniversities();
        void AddApplication(ApplicationBEAN application);
        List<Application> GetListOfApplications(int id);
        List<Application> GetApplicationByApplicant(int id);
        void UpdateOffer(int applicationId, int universityId, string offer);
        List<Application> GetApplicationByUniAndApplicant(int applicantId, int universityId);
        int GetApplicantIdByUserId(string userId);
        IList<ApplicationBEAN> GetListOfApplicationsByApplicantId(int applicantId);
        ApplicationBEAN GetApplicationByApplicationId(int applicationId);
        string GetUniversityById(int universityId);
        void SetApplicationFirm(int applicationId);
        int GetNumberOfApplicationsByApplicantId(int applicantId);
        ApplicantBEAN GetApplicantProfileByUserId(string userId);
        List<Application> GetApplicationByUniAndApplicationId(int applicationId, int universityId);
        List<Application> GetApplicationsByStateOfOffer(int universityId, char stateOfOffer);
        void AddUniversity(University university);

    }
}
