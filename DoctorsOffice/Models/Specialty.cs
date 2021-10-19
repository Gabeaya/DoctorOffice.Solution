using System.Collections.Generic;

namespace DoctorsOffice.Models
{
    public class Specialty
    {
        public Specialty()
        {
            this.JoinEntities3 = new HashSet<DoctorSpecialty>();
            this.JoinEntities2 = new HashSet<SpecialtyPatient>();
        }

        public int SpecialtyId { get; set; }
        public string Name { get; set; }


        public virtual ICollection<DoctorSpecialty> JoinEntities3 { get; set; }
        public virtual ICollection<SpecialtyPatient> JoinEntities2 { get; set; }
    }
}