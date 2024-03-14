namespace QalamAndNoor.Models
{
    public class IlnessMedicalRecord
    {
        public int ID { get; set; }
        public int IlnessId { get; set; }
        public int MedicalRecordId { get; set; }
        public string? Note { get; set; }
    }
}
