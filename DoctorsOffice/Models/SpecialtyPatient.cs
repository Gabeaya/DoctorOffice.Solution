namespace DoctorsOffice.Models
{
  public class SpecialtyPatient
  {       
    public int SpecialtyPatientId { get; set; }
    public int PatientId { get; set; }
    public int SpecialtyId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Specialty Specialty { get; set; }
  }
}