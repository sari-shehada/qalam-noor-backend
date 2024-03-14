using QalamAndNoor.Shared;

namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class StudentReport
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int ExamId { get; set; }
        public ExamTypeEnum  ExamType { get; set; }
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int ActualCount { get; set; }
        public int ExpectedCount { get; set; }
    }
}
