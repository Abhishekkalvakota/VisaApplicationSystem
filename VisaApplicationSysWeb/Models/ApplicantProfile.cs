using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class ApplicantProfile
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }
        public string CurrentAddress { get; set; }
        [Required(ErrorMessage = "Passport Number is required.")]
        public string PassportNumber { get; set; }

        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".pdf", ErrorMessage = "Please upload a valid PDF file.")]
        public string?  PassportFilePath { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Intended Arrival Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime IntendedArrivalDate { get; set; }

        [Required(ErrorMessage = "Intended Departure Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime IntendedDepartureDate { get; set; }

     
        public int? StudentVisaFormId { get; set; }
        public StudentVisaForm StudentVisaForm { get; set; }

        
        public int? EmploymentVisaFormId { get; set; }
        public EmploymentVisaForm EmploymentVisaForm { get; set; }

        
        public int? TouristVisaFormId { get; set; }
        public TouristVisaForm TouristVisaForm { get; set; }

        
        public int? BusinessVisaFormId { get; set; }
        public BusinessVisaForm BusinessVisaForm { get; set; }

       
        public int VisaTypeId { get; set; }
        public VisaType VisaType { get; set; }

     
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Business Title")]
        [Required(ErrorMessage = "Business Title is required")]
        public string BusinessTitle { get; set; }

        [Display(Name = "Business Nature")]
        [Required(ErrorMessage = "Business Nature is required")]
        public string BusinessNature { get; set; }

        [Display(Name = "Current Employer")]
        [Required(ErrorMessage = "Current Employer is required")]
        public string CurrentEmployer { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Job Title is required")]
        public string JobTitle { get; set; }

        [Display(Name = "Monthly Salary")]
        [Required(ErrorMessage = "Monthly Salary is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid salary")]
        public decimal MonthlySalary { get; set; }

        [Display(Name = "Contract Start Date")]
        [Required(ErrorMessage = "Contract Start Date is required")]
        public DateTime ContractStartDate { get; set; }

        [Display(Name = "Contract End Date")]
        [Required(ErrorMessage = "Contract End Date is required")]
        public DateTime ContractEndDate { get; set; }

        [Display(Name = "Passport Photo")]
        [Required(ErrorMessage = "Passport Photo is required")]
        public string PassportPhotoPath { get; set; }

        [Display(Name = "Resume")]
        [Required(ErrorMessage = "Resume is required")]
        public string ResumePath { get; set; }

        [Display(Name = "Employment Contract")]
        [Required(ErrorMessage = "Employment Contract is required")]
        public string EmploymentContractPath { get; set; }

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

        
        [Display(Name = "Highest Education Level Mark Sheet")]
        public string HighestEducationLevelMarkSheetPath { get; set; }

        [Display(Name = "Test Card Path")]
        public string TestCardPath { get; set; }

        [Display(Name = "Test Card Path")]
        public string Passportpath { get; set; }

        [Display(Name = "Travel Itinerary")]
        [Required(ErrorMessage = "Travel Itinerary is required")]
        public string TravelItineraryPath { get; set; }

        [Display(Name = "Hotel Reservation")]
        [Required(ErrorMessage = "Hotel Reservation is required")]
        public string HotelReservationPath { get; set; }

        public string NewPassportFile { get; set; }
        public string NewResumeFile { get; set; }
        public string NewTestCardFile { get; set; }
        public string NewEmploymentContractFile { get; set; }
        public string NewTravelItineraryFile { get; set; }
        public string NewHotelReservationFile { get; set; }

    }
    


}
