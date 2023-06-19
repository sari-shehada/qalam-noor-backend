namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class ClassReportsDto
    {
        public Class CLass { get; set; }
        public List<CourseReportsDto> CourseReports { get; set; }=new List<CourseReportsDto>();
    }
    public class CourseReportsDto
    {
        public Course Course { get; set; }
        public List<ClassroomReportsDto> ClassroomReports { get; set; } = new List<ClassroomReportsDto>();
    }

    public class ClassroomReportsDto
    {
        public ClassRoom Classroom { get; set; }
        public List<ExamsReportsDto> ExamsReports{ set; get; } = new List<ExamsReportsDto>();
    }

    public class ExamsReportsDto
    {
        public Exam Exam { get; set; }
    }
}
