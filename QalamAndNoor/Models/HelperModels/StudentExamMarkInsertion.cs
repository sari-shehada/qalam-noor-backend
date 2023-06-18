namespace QalamAndNoor.Models.HelperModels
{
    public class StudentExamMarkInsertion
    {
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public Dictionary<int, double> StudentMark { get; set; } = new Dictionary<int, double>();
    }
}
