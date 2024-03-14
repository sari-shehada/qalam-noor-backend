using QalamAndNoor.Shared;

namespace QalamAndNoor.Models.HelperModels
{
    public class StudentPsychologicalStatusInfo
    {
        public int PsychologicalStatusMedicalRecordId { get; set; }
        public string PsychologicalStatusName { get; set; }
        public LevelEnum StatusLevel { get; set; }
    }
}
