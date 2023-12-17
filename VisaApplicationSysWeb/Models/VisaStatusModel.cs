using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class VisaStatusModel
    {
        [Key]
        public int VisaStatusID { get; set; }

       
        public string VisaSatus { get; set; }

   
        public string VisaType { get; set; }

       
        public string Email { get; set; }

        public string FullName { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantID { get; set; }

        public Applicant tblApplicant { get; set; }
    }
}
