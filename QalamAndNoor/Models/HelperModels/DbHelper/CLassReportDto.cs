using QalamAndNoor.Shared;

namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class ClassReportDTO
    {
        public ClassReportDTO()
        {

        }

        public int ClassId { get; set; }
        public String ClassName { get; set; } = string.Empty;
        public List<CourseReportDTO> CourseReports { get; set; } = new List<CourseReportDTO>();
    }

    public class CourseReportDTO
    {
        public int CourseId { get; set; }
        public String CourseName { get; set; } = string.Empty;
        public List<ClassroomReportDTO> ClassroomReports { get; set; } = new List<ClassroomReportDTO>();
    }

    public class ClassroomReportDTO
    {
        public int ClassroomId { get; set; }
        public String ClassroomName { get; set; } = string.Empty;
        public List<ExamReportDTO> ExamReports { get; set; } = new List<ExamReportDTO>();
    }

    public class ExamReportDTO
    {
        public int ExamId { get; set; }
        public ExamTypeEnum ExamType { get; set; }
        public int ExpectedCount { get; set; }
        public int ActualCount { get; set; }
    }
}
