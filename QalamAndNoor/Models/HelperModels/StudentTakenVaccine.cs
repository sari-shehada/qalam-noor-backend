namespace QalamAndNoor.Models.HelperModels
{
    public class StudentTakenVaccine
    {
        public int TakenVaccineId { get; set; }
        public string VaccineName { get; set; } = string.Empty;
        public DateTime ShotDate { get; set; }
        public string? Note { get; set; }
    }
}
