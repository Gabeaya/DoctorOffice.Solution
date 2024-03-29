using Microsoft.EntityFrameworkCore;

namespace DoctorsOffice.Models
{
  public class DoctorsOfficeContext : DbContext
  {
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<DoctorSpecialty> DoctorSpecialty { get; set; }
    public DbSet<DoctorPatient> DoctorPatient { get; set; } 

    public DbSet<SpecialtyPatient> SpecialtyPatient { get; set; }

    public DoctorsOfficeContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}