using System.ComponentModel.DataAnnotations.Schema;

namespace SyntaxMedical.web.Data
{
    public class Patient:basePerson
    {
       public DateTime DateofBirth { get; set; }
	    [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
		
       public string StreetAddress { get; set; }
       public string City { get; set; }
	   
        [ForeignKey("ParishId")]
        public Parish Parish { get; set; }
        public int ParishId { get; set; }
		
		
       public string ContactName { get; set; }
       public string EContactNo { get; set; }
       public string ContactAddress { get; set; }
	   
	    [ForeignKey("ERelationshipId")]
        public EmergencyRelationship EmergencyRelationship { get; set; }
        public int ERelationshipId { get; set; }

    }
}
