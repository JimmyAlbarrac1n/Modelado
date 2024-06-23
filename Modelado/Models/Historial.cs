namespace Modelado.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Paciente Patient { get; set; }
        public string Details { get; set; }
        public DateTime DateRecorded { get; set; }
    }
}
