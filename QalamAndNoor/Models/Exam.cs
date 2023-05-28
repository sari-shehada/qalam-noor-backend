using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Exam
    {
        public int ID { get; set; }
        public ExamTypeEnum  Type { get; set; }
        public int Percentage { get; set; }
        public int ClassId { get; set; }
        public int Sequence { get; set; }
    }
}
