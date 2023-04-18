using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Semester
    {
        public int ID { get; set; }
        public SemesterTypeEnum Type { get; set; }
        public int YearRecordId { get; set; }
    }
}
