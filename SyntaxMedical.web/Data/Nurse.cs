using System.ComponentModel.DataAnnotations.Schema;

namespace SyntaxMedical.web.Data
{
    public class Nurse:basePerson
    {
       public DateTime LicensureDate { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

    }
}
