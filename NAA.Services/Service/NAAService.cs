using NAA.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.DAO;
using NAA.Data.BEANS;

namespace NAA.Services.Service
{
    public class NAAService : INAAService
    {
        private NAADAO naaDAO;
        public NAAService()
        {
            naaDAO = new NAADAO();
        }

        //public IList<ApplicantProfile> GetProfiles()
        //{
        //    return naaDAO.GetProfiles();
        //}

        public IList<ApplicantBEAN> GetProfiles()
        {
            return naaDAO.GetProfiles();
        }

        public ApplicantProfile GetProfile(int id)
        {
            return naaDAO.GetProfile(id);
        }

        public void AddProfile(ApplicantProfile profile)
        {
            naaDAO.AddProfile(profile);
        }

        public void EditProfile(ApplicantProfile profile)
        {
            naaDAO.EditProfile(profile);
        }

        public void DeleteProfile(ApplicantProfile profile)
        {
            naaDAO.DeleteProfile(profile);
        }

        public IList<University> DisplayUniversities()
        {
            return naaDAO.GetUniversities();
        }

        public void AddApplication(ApplicationBEAN application)
        {
            naaDAO.AddApplication(application);
        }

        public List<Application> GetListOfApplications(int id)
        {
            return naaDAO.GetListOfApplications(id);
        }

        public List<Application> GetApplicationByApplicant(int id)
        {
            return naaDAO.GetApplicationByApplicant(id);
        }

        public void UpdateOffer(int applicationId, int universityId, string offer)
        {
            naaDAO.UpdateOffer(applicationId, universityId, offer);
        }

        public List<Application> GetApplicationByUniAndApplicant(int applicantId, int universityId)
        {
            return naaDAO.GetApplicationByUniAndApplicant(applicantId, universityId);
        }

        public int GetApplicantIdByUserId(string userId)
        {
            return naaDAO.GetApplicantIdByUserId(userId);
        }
        public IList<ApplicationBEAN> GetListOfApplicationsByApplicantId(int applicantId)
        {
            return naaDAO.GetListOfApplicationsByApplicantId(applicantId);
        }
        public ApplicationBEAN GetApplicationByApplicationId(int applicationId)
        {
            return naaDAO.GetApplicationByApplicationId(applicationId);
        }

        public string GetUniversityById(int universityId)
        {
            return naaDAO.GetUniversityById(universityId);
        }
        public void SetApplicationFirm(int applicationId)
        {
            naaDAO.SetApplicationFirm(applicationId);
        }
        public int GetNumberOfApplicationsByApplicantId(int applicantId)
        {
            return naaDAO.GetNumberOfApplicationsByApplicantId(applicantId);
        }
        public ApplicantBEAN GetApplicantProfileByUserId(string userId)
        {
            return naaDAO.GetApplicantProfileByUserId(userId);
        }
        public List<Application> GetApplicationByUniAndApplicationId(int applicationId, int universityId)
        {
            return naaDAO.GetApplicationByUniAndApplicationId(applicationId, universityId);
        }
        public List<Application> GetApplicationsByStateOfOffer(int universityId, char stateOfOffer)
        {
            return naaDAO.GetApplicationsByStateOfOffer(universityId, stateOfOffer);
        }
        public void AddUniversity(University university)
        {
            naaDAO.AddUniversity(university);
        }
    }
}
