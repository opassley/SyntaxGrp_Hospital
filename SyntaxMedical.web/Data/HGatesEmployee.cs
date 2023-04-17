using Microsoft.AspNetCore.Identity;

namespace SyntaxMedical.web.Data
{
    public class HGatesEmployee : IdentityUser
    {
        public string StaffID { get; set; }
        public string DateJoined { get; set; }
    }
}
