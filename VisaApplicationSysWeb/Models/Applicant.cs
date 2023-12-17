using System.ComponentModel.DataAnnotations;

namespace VisaApplicationSysWeb.Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantID { get; set; }

        public string FullName{ get; set; }

        public string Email { get; set; }

        public string VisaType { get; set; }

        public int VisaTypeId { get; set; }

        public bool IsVisaApplied { get; set; }


        public ICollection<StudentVisaForm> tblStudentVisaForm { get; set; }
        public ICollection<TouristVisaForm> TouristVisaForms { get; set; }
        public ICollection<EmploymentVisaForm> EmploymentVisaForms { get; set; }
        public ICollection<BusinessVisaForm> BusinessVisaForms { get; set; }
        public ICollection<VisaStatusModel> tblVisaStatus { get; set; }
    }
}
