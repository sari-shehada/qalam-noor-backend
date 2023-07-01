namespace QalamAndNoor.Models.HelperModels
{
    public class StudentYearRecords
    {
        public SchoolYear? SchoolYear { get; set; }
        public List<Semester> Semesters { get; set; } = new List<Semester>();
        public Class? Class { get; set; }
        public ClassRoom? ClassRoom { get; set; }
        public YearRecord? YearRecord { get; set; }
    }
}
