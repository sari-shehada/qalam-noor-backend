namespace QalamAndNoor.Models.HelperModels
{
    public class StudentVaccineInfo
    {
        public int TakentVaccineId { get; set; }
        public string VaccinName { get; set; } = string.Empty;
        public DateTime ShotDate { get; set; }
        public string? Note { get; set; }
    }

}
