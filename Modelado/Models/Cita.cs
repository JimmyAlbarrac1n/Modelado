namespace Modelado.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Paciente Patient { get; set; }
        public string Specialist { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
