namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class FinalStudentScore
    {
        public List<TotalStudentMark> TotalStudentMarks { get; set; }
        public double TotalGrade { get; set; }
        public bool DidPassYear { get; set; }
    }
}
