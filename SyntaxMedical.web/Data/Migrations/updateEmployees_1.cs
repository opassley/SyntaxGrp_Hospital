using Microsoft.AspNetCore.Identity;

namespace SyntaxMedical.web.Data
{
    public class updateEmployees_1 : IdentityUser
    {
        public string? StaffID { get; set; }
        public string? DateJoined { get; set; }
    }
}
