using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class PsychologicalStatusMedicalRecord
    {
        public int ID { get; set; }
        public int MedicalRecordId { get; set; }
        public int PsychologicalStatusId { get; set; }
        public LevelEnum StatusLevel { get; set; }
    }
}
