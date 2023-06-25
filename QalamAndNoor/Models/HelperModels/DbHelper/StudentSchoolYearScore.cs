namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class StudentSchoolYearScore
    {
        public List<StudentSemesterScore> StudentSemesterScores { get; set; } = new List<StudentSemesterScore>();
        public Dictionary<int, double> TotalCourseGrades { get; set; } = new Dictionary<int, double>();
        public bool DidPassSchoolYear { get; set; }

        public double TotalSchoolYearGrade { get; set; }
    }
}
