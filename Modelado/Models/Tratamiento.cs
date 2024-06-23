namespace Modelado.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Paciente Patient { get; set; }
        public string Description { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string SideEffects { get; set; }
        public DateTime DatePrescribed { get; set; }
    }
}
