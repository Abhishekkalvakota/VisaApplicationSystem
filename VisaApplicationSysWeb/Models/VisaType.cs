using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSysWeb.Models
{
    public class VisaType
    {
        [Key]
        public int VisaTypeId { get; set; }

        public string TypeName { get; set; }

        [ForeignKey("VisaTypeId")]
        public virtual ICollection<StudentVisaForm> StudentVisaForms { get; set; }

        [ForeignKey("VisaTypeId")]
        public virtual ICollection<TouristVisaForm> TouristVisaForms { get; set; }

        [ForeignKey("VisaTypeId")]
        public virtual ICollection<EmploymentVisaForm> EmploymentVisaForms { get; set; }

        [ForeignKey("VisaTypeId")]
        public virtual ICollection<BusinessVisaForm> BusinessVisaForms { get; set; }
    }

}
