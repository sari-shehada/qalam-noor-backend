namespace QalamAndNoor.Models.HelperModels
{
    public class LateStudentEnrollmentSemesterResult
    {
        public int SemesterId { get; set; }

        public List<LateStudentEnrollmentCourseResult> CourseResults { get; set; } = new List<LateStudentEnrollmentCourseResult>();
    }
}
