namespace QalamAndNoor.Models
{
    public class SchoolYear
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFinished { get; set; }
        public int? PreviousSchoolYearId { get; set; }
    }
}
