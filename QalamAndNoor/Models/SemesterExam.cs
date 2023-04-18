namespace QalamAndNoor.Models
{
    public class SemesterExam
    {
        public int ID { get; set; }
        public int ExamId { get; set; }
        public int SemesterId { get; set; }
        public double ObtainedGrade { get; set; }
        public int CourseId { get; set; }
    }
}
