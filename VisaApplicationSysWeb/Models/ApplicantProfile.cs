using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VisaApplicationSysWeb.Models
{
    public class ApplicantProfile
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Passport Number is required.")]
        public string PassportNumber { get; set; }

        public string PassportFilePath { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Application Status is required.")]
        public string ApplicationStatus { get; set; }

        [Required(ErrorMessage = "Intended Arrival Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime IntendedArrivalDate { get; set; }

        [Required(ErrorMessage = "Intended Departure Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime IntendedDepartureDate { get; set; }

        [Required(ErrorMessage = "Visa Types are required.")]
        public List<VisaType> VisaTypes { get; set; }

    }
    public class VisaType
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }


}
