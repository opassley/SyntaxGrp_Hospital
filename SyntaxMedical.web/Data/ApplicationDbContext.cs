using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SyntaxMedical.web.Data
{
    public class ApplicationDbContext : IdentityDbContext<HGatesEmployee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Parish> Parishes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<EmergencyRelationship> EmergencyRelationships { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Intake> Intakes { get; set; }

    }
}