using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class TouristVisaForm
    {

        [Key]
        public int TouristVisaFormId { get; set; }

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

        [Display(Name = "Intended Arrival Date")]
        [Required(ErrorMessage = "Intended Arrival Date is required")]
        public DateTime IntendedArrivalDate { get; set; }

        [Display(Name = "Intended Departure Date")]
        [Required(ErrorMessage = "Intended Departure Date is required")]
        public DateTime IntendedDepartureDate { get; set; }

        [Display(Name = "Passport Photo")]
        [Required(ErrorMessage = "Passport Photo is required")]
        public string PassportPhotoPath { get; set; }

        [Display(Name = "Travel Itinerary")]
        [Required(ErrorMessage = "Travel Itinerary is required")]
        public string TravelItineraryPath { get; set; }

        [Display(Name = "Hotel Reservation")]
        [Required(ErrorMessage = "Hotel Reservation is required")]
        public string HotelReservationPath { get; set; }

        [ForeignKey("ApplicantProfile")]
        public int ApplicantId { get; set; }
        public ApplicantProfile ApplicantProfile { get; set; }

        [Display(Name = "Test Card Path")]
        public string Passportpath { get; set; }


        [ForeignKey("VisaType")]
        public int VisaTypeId { get; set; }
        public VisaType VisaType { get; set; }
    }
}
