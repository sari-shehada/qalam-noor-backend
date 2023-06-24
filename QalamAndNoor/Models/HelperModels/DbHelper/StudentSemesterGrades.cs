using System.Security.Principal;
using QalamAndNoor.Shared;

namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class StudentSemesterGrades
    {
        public Employee Teacher { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public double TotalGrade { get; set; }
        public Dictionary<int, double> Grades { get; set; } = new Dictionary<int, double>();
        public double CourseGrade { get; set; }
        public bool? DidPassCourse { get; set; }
        public bool IsOnlyDrop { get; set; }

    }
}
