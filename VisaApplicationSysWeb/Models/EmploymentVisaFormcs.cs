using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class EmploymentVisaForm 
    {
        [Key]
        public int EmploymentVisaFormId { get; set; }

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

        [Display(Name = "Test Card Path")]
        public string Passportpath { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantID { get; set; }

       

        public bool IsVisaApplied { get; set; }

        public Applicant tblApplicant { get; set; }

    }
}
