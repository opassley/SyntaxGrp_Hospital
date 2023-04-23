using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace SyntaxMedical.web.Models;

    public class ConditionVM
    {   
        public int Id { get; set; }
        
        [Display(Name = "Names of Existing Conditions")] 
        public string? ConditionName { get; set; }
       
    }

