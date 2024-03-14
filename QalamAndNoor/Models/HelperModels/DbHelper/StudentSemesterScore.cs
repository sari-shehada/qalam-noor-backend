namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class StudentSemesterScore
    {

        public List<StudentSemesterGrades> StudentSemesterGrades { get; set; }
        public bool DidPassSemester { get; set; }
        public double TotalSemesterGrade { get; set; }
    }
}
