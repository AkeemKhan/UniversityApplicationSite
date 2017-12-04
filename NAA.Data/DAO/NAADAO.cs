using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.BEANS;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class NAADAO : INAADAO
    {
        private NAAEntities context;
        public NAADAO() 
        {
            context = new NAAEntities(); 
        }

        public IList<ApplicantBEAN> GetProfiles()
        {
            IQueryable<ApplicantBEAN> abeans;
            abeans = from appProf in context.ApplicantProfile
                             select new ApplicantBEAN {
                                 Id = appProf.Id,
                                 ApplicantName = appProf.ApplicantName,
                                 ApplicantAddress= appProf.ApplicantAddress,
                                 Phone = appProf.Phone,
                                 Email = appProf.Email,
                                 UserId = appProf.UserId
                             };
            return abeans.ToList<ApplicantBEAN>();
        }
        //public IList<ApplicantProfile> GetProfiles()
        //{
        //    IQueryable<ApplicantProfile> profiles;
        //    profiles = from profile in context.ApplicantProfile select profile;
        //    return profiles.ToList<ApplicantProfile>();
        //}

        public ApplicantProfile GetProfile(int id)
        {
            IQueryable<ApplicantProfile> singleProfile;
            singleProfile = from profiles in context.ApplicantProfile where profiles.Id == id select profiles;
            return singleProfile.First();
        }
        public void AddProfile(ApplicantProfile profile)
        {
            context.ApplicantProfile.Add(profile);
            context.SaveChanges();
        }

        public void EditProfile(ApplicantProfile profile)
        {
            //Obtain existing profile to Edit
            ApplicantProfile existingProfile = (from prof
                                    in context.ApplicantProfile
                                    where prof.Id == profile.Id
                                    select prof).ToList<ApplicantProfile>().First();

            //Assign new values

            existingProfile.ApplicantName = profile.ApplicantName;
            existingProfile.ApplicantAddress = profile.ApplicantAddress;
            existingProfile.Phone = profile.Phone;
            existingProfile.Email = profile.Email;
            existingProfile.UserId = profile.UserId;
            context.SaveChanges();

        }

        public void DeleteProfile(ApplicantProfile profile)
        {
            context.ApplicantProfile.Remove(profile);
            context.SaveChanges();
        }

        public IList<University> GetUniversities()
        {
            IQueryable<University> universities;
            universities = from uni in context.University select uni;
            return universities.ToList<University>();
        }

        public void AddApplication(ApplicationBEAN application)
        {
            Application newApplication = new Application();
            newApplication.ApplicationId = application.Id;
            newApplication.ApplicantId = application.ApplicantId;
            newApplication.CourseName = application.CourseName;
            newApplication.PersonalStatement = application.PersonalStatement;
            newApplication.TeacherContactDetails = application.TeacherContactDetails;
            newApplication.TeacherReference = application.TeacherReference;
            newApplication.UniversityId = application.UniversityId;
            newApplication.Firm = false;
            newApplication.UniversityOffer = "P";

            context.Application.Add(newApplication);

            //Code for validation checking found:
            //http://stackoverflow.com/questions/19520022/validation-error-on-savechanges
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            
        }

        public IList<ApplicationBEAN> GetAllApplications()
        {
            IQueryable<ApplicationBEAN> appbeans;
            appbeans = from application in context.Application
                     select new ApplicationBEAN
                     {
                            Id = application.ApplicantId,
                            ApplicantId = application.ApplicantId,
                            CourseName = application.CourseName,
                            PersonalStatement = application.PersonalStatement,
                            TeacherContactDetails = application.TeacherContactDetails,
                            TeacherReference = application.TeacherReference,
                            UniversityId = application.UniversityId,
                            //Firm = application.Firm

                     };
            return appbeans.ToList<ApplicationBEAN>();
        }

        public List<Application> GetListOfApplications(int id)
        {
            IQueryable<Application> applications;
            applications = from appl in context.Application where appl.UniversityId == id select appl;
            return applications.ToList<Application>();
        }

        public List<Application> GetApplicationByApplicant(int id)
        {
            IQueryable<Application> applications;
            applications = from appl in context.Application where appl.ApplicantId == id select appl;
            return applications.ToList<Application>();
        }

        public void UpdateOffer(int applicationId, int universityId, string offer)
        {
            offer = offer.ToUpper();
            Application application = (from app
                                in context.Application
                                where (app.ApplicationId == applicationId) && (app.UniversityId == universityId)
                                select app).ToList<Application>().First();

            if (application != null)
            {
                application.UniversityOffer = offer;
                context.SaveChanges();
            }
            
        }

        public List<Application> GetApplicationByUniAndApplicant(int applicantId, int universityId)
        {
            IQueryable<Application> applications;
            applications = from appl in context.Application 
                           where appl.ApplicantId == applicantId 
                           && appl.UniversityId == universityId 
                           select appl;
            return applications.ToList<Application>();
        }
        public int GetApplicantIdByUserId(string userId)
        {
            ApplicantProfile applicantProfile = 

                (from appProf in context.ApplicantProfile 
                 where appProf.UserId == userId 
                 select appProf).ToList<ApplicantProfile>().First();
            return applicantProfile.Id;
        }
        public IList<ApplicationBEAN> GetListOfApplicationsByApplicantId(int applicantId)
        {
            IQueryable<ApplicationBEAN> appbeans;
            appbeans = from application in context.Application
                       where application.ApplicantId == applicantId
                       select new ApplicationBEAN
                       {
                           Id = application.ApplicationId,
                           ApplicantId = application.ApplicantId,
                           CourseName = application.CourseName,
                           PersonalStatement = application.PersonalStatement,
                           TeacherContactDetails = application.TeacherContactDetails,
                           TeacherReference = application.TeacherReference,
                           UniversityId = application.UniversityId,
                           UniversityOffer = application.UniversityOffer,
                           //UniversityName = GetUniversityById(application.UniversityId),
                           firm = application.Firm

                       };
            IList<ApplicationBEAN> listOfBEANS = appbeans.ToList<ApplicationBEAN>();
            
            foreach(ApplicationBEAN bean in listOfBEANS)
            {
                bean.UniversityName = GetUniversityById(bean.UniversityId);
            }

            return listOfBEANS;
        }
        public ApplicationBEAN GetApplicationByApplicationId(int applicationId)
        {
            IQueryable<ApplicationBEAN> appbeans;
            appbeans = from application in context.Application
                       where application.ApplicationId == applicationId
                       select new ApplicationBEAN
                       {
                           Id = application.ApplicationId,
                           ApplicantId = application.ApplicantId,
                           CourseName = application.CourseName,
                           PersonalStatement = application.PersonalStatement,
                           TeacherContactDetails = application.TeacherContactDetails,
                           TeacherReference = application.TeacherReference,
                           UniversityId = application.UniversityId,
                           UniversityOffer = application.UniversityOffer,
                           firm = application.Firm,

                       };

            ApplicationBEAN bean = appbeans.ToList<ApplicationBEAN>().First();
            bean.UniversityName = GetUniversityById(bean.UniversityId);
            return bean;
        }

        public string GetUniversityById(int universityId)
        {
            University university =
                (from uni in context.University
                 where uni.UniversityId == universityId
                 select uni).ToList<University>().First();
            return university.UniversityName;
        }
        public void SetApplicationFirm(int applicationId)
        {
            Application applicationToEdit = 
                        (from app in context.Application
                         where app.ApplicationId == applicationId
                            select app).ToList<Application>().First();

            List<Application> listOfApplications = (from app in context.Application
                                                    where app.ApplicantId == applicationToEdit.ApplicantId
                                                    select app).ToList<Application>();

            foreach(Application item in listOfApplications)
            {
                item.Firm = false;
            }

            if (applicationToEdit.UniversityOffer == "C" || applicationToEdit.UniversityOffer == "U")
            {
                applicationToEdit.Firm = true;
            }
            
            context.SaveChanges();

            /* U = Unconditional Offer
             * C = Conditional Offer
             * R = Rejecting Offer
             * p = Pending
            */


        }
        public int GetNumberOfApplicationsByApplicantId(int applicantId)
        {
            List<Application> listOfApplications = (from app in context.Application
                                                    where app.ApplicantId == applicantId
                                                    select app).ToList<Application>();
            return listOfApplications.Count;
        }
        public ApplicantBEAN GetApplicantProfileByUserId(string userId)
        {
            IQueryable<ApplicantBEAN> appProf;
            appProf = from applicant in context.ApplicantProfile
                      where applicant.UserId == userId
                       select new ApplicantBEAN
                       {
                           ApplicantAddress = applicant.ApplicantAddress,
                           ApplicantName = applicant.ApplicantName,
                           Email = applicant.Email,
                           Id = applicant.Id,
                           Phone = applicant.Phone,
                           UserId = applicant.UserId
                       };
            ApplicantBEAN bean = appProf.ToList<ApplicantBEAN>().First();
            return bean;
        }
        public List<Application> GetApplicationByUniAndApplicationId(int applicationId, int universityId)
        {
            IQueryable<Application> applications;
            applications = from appl in context.Application
                           where appl.ApplicationId == applicationId
                           && appl.UniversityId == universityId
                           select appl;
            return applications.ToList<Application>();
        }
        public List<Application> GetApplicationsByStateOfOffer(int universityId, char stateOfOffer)
        {
            string offerValue = Char.ToUpper(stateOfOffer).ToString();
            IQueryable<Application> applications;
            applications = from appl in context.Application
                           where appl.UniversityId == universityId
                           && appl.UniversityOffer == offerValue
                           select appl;
            return applications.ToList<Application>();
        }
        public void AddUniversity(University university)
        {
            context.University.Add(university);
            context.SaveChanges();
        }
    }
}
