using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class VisaStatusModel
    {
        [Key]
        public int ApplicantId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string VisaType { get; set; }
        public string Status { get; set; }
    }
}
