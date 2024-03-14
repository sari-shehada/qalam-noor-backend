namespace QalamAndNoor.Models.HelperModels
{
    public class StudentExamMark
    {
        public Student Student { get; set; }
        public YearRecord YearRecord { get; set; }
        public SemesterExam? SemesterExam { get; set; }
        public Father Father { get; set; }
    }
}
