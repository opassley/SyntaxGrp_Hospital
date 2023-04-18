using System.ComponentModel.DataAnnotations.Schema;

namespace SyntaxMedical.web.Data
{
    public class Intake
    {
       public int Id { get; set; }
       
	   [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
		
		public DateTime IntakeDate{get; set; }
		
	   
        [ForeignKey("ConditionId")]
        public Condition Condition { get; set; }
        public int ConditionId { get; set; }
		
		[ForeignKey("ProcedureId")]
        public Procedure Procedure { get; set; }
        public int ProcedureId { get; set; }
		
		[ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
		
		[ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

    }
}
