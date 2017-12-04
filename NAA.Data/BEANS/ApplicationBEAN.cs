using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NAA.Data.BEANS
{

    public class ApplicationBEAN
    {
        public ApplicationBEAN() { }
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string CourseName { get; set; }
        public int UniversityId { get; set; }

        [Required(ErrorMessage = "Field is Required.")]
        [MinLength(3, ErrorMessage = "Too Short.")]
        public string PersonalStatement { get; set; }
        public string TeacherReference { get; set; }
        [Required(ErrorMessage = "Field is Required.")]
        [MinLength(3, ErrorMessage = "Too Short.")]
        public string TeacherContactDetails { get; set; }
        public bool? firm { get; set; }
        public string UniversityOffer { get; set; }
        public string UniversityName { get; set; }

    }
}

/*
    [ApplicationId]         INT            IDENTITY (1, 1) NOT NULL,
    [ApplicantId]           INT            NOT NULL,
    [CourseName]            NVARCHAR (50)  NOT NULL,
    [UniversityId]          INT            NOT NULL,
    [PersonalStatement]     NVARCHAR (MAX) NOT NULL,
    [TeacherReference]      NVARCHAR (MAX) NULL,
    [TeacherContactDetails] NVARCHAR (MAX) NOT NULL,
    [UniversityOffer]       NVARCHAR (10)  NULL,
    [Firm]                  BIT            NULL,
*/