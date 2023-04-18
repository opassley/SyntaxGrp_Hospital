using System.ComponentModel.DataAnnotations.Schema;

namespace SyntaxMedical.web.Data
{
    public class Doctor:basePerson
    {
       public DateTime LicensureDate { get; set; }
        [ForeignKey("SpecializationId")]
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }

    }
}
