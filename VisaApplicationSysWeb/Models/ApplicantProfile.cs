namespace VisaApplicationSysWeb.Models
{
    public class ApplicantProfile
    {
        public int ApplicantId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentAddress { get; set; }
        public string PassportNumber { get; set; }
        public string PassportFilePath { get; set; }
        public string Nationality { get; set; }
        public DateTime IntendedArrivalDate { get; set; }
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

        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string BusinessTitle { get; set; }
        public string BusinessNature { get; set; }
        public string CurrentEmployer { get; set; }
        public string JobTitle { get; set; }
        public decimal MonthlySalary { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string PassportPhotoPath { get; set; }
        public string ResumePath { get; set; }
        public string EmploymentContractPath { get; set; }
        public string HighestEducationLevel { get; set; }
        public string InstitutionName { get; set; }
        public string CourseTitle { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public string ProofOfFundsType { get; set; }
        public string LanguageTestTaken { get; set; }
        public string LanguageTestScore { get; set; }
        public string HighestEducationLevelMarkSheetPath { get; set; }
        public string TestCardPath { get; set; }
        public string Passportpath { get; set; }
        public string TravelItineraryPath { get; set; }
        public string HotelReservationPath { get; set; }
        public string NewPassportFile { get; set; }
        public string NewResumeFile { get; set; }
        public string NewTestCardFile { get; set; }
        public string NewEmploymentContractFile { get; set; }
        public string NewTravelItineraryFile { get; set; }
        public string NewHotelReservationFile { get; set; }
    }
}
