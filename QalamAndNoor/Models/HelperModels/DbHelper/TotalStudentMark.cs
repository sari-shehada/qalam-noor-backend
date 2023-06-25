namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class TotalStudentMark
    {
        public int CourseId { get; set; }
        public string  CourseName { get; set;}
        public bool RequiredToPass { get; set; }
        public int RequiredGradeToPass { get; set; }
        public double AverageGrade { get; set; }
        public bool DidPass { get; set; }
    }

}
