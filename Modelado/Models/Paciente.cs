namespace Modelado.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string MedicalHistory { get; set; }

        public ICollection<Cita> Citas { get; set; }
        public ICollection<Tratamiento> Tratamientos { get; set; }
    }
}
