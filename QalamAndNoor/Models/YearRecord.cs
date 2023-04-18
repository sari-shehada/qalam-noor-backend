namespace QalamAndNoor.Models
{
    public class YearRecord
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int ClassRoomSchoolYearId { get; set; }
        public bool DidPass { get; set; }
    }
}
