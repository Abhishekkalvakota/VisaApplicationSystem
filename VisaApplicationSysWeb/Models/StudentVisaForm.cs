using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class StudentVisaForm
    {

        [Key]
        public int StudentVisaFormId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Nationality")]
        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }

        [Display(Name = "Passport Number")]
        [Required(ErrorMessage = "Passport Number is required")]
        public string PassportNumber { get; set; }

        [Display(Name = "Current Address")]
        [Required(ErrorMessage = "Current Address is required")]
        public string CurrentAddress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Highest Education Level")]
        [Required(ErrorMessage = "Highest Education Level is required")]
        public string HighestEducationLevel { get; set; }

        [Display(Name = "Institution Name")]
        [Required(ErrorMessage = "Institution Name is required")]
        public string InstitutionName { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Course Title is required")]
        public string CourseTitle { get; set; }

        [Display(Name = "Expected Start Date")]
        [Required(ErrorMessage = "Expected Start Date is required")]
        public DateTime ExpectedStartDate { get; set; }

        [Display(Name = "Proof of Funds Type")]
        [Required(ErrorMessage = "Proof of Funds Type is required")]
        public string ProofOfFundsType { get; set; }

        [Display(Name = "Language Test Taken")]
        public string LanguageTestTaken { get; set; }

        [Display(Name = "Language Test Score")]
        public string LanguageTestScore { get; set; }

        // New property for mark sheet of the highest education level
        [Display(Name = "Highest Education Level Mark Sheet")]
        public string HighestEducationLevelMarkSheetPath { get; set; }

        [Display(Name = "Passport Photo")]
        [Required(ErrorMessage = "Passport Photo is required")]
        public string PassportPhotoPath { get; set; }

        [Display(Name = "Resume")]
        public string ResumePath { get; set; }

        [Display(Name = "Test Card Path")]
        public string TestCardPath { get; set; }

        [Display(Name = "Passport path")]
        public string Passportpath { get; set; }


        [ForeignKey("ApplicantProfile")]
        public int ApplicantId { get; set; }
        public ApplicantProfile ApplicantProfile { get; set; }

        [ForeignKey("VisaType")]
        public int VisaTypeId { get; set; }
        public VisaType VisaType { get; set; }


        [Display(Name = "Visa Status")]
        public string VisaStatus { get; set; }
    }
}
