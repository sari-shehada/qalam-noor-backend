namespace QalamAndNoor.Models.HelperModels
{
    public class LateStudentEnrollmentCourseResult
    {
        public int CourseId { get; set; }

        public Dictionary<int, double> Grades { get; set; } = new Dictionary<int, double>();
    }
}
