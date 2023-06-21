using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class YearRecord
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int? ClassRoomSchoolYearId { get; set; }
        public StudentStatusEnum  Status { get; set; }
        public int? YearGrade { get; set; }
    }
}
