namespace QalamAndNoor.Models
{
    public class TokenVaccine
    {
        public int ID { get; set; }
        public int VaccineId { get; set; }
        public int MedicalRecordId { get; set; }
        public DateTime ShotDate { get; set; }
        public string? Note { get; set; }
    }
}
