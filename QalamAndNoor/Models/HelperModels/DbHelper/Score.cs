using QalamAndNoor.Shared;

namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class Score
    {
        public string CourseName { get; set; } = string.Empty;
        public double TotalGrade { get; set; }
        public Dictionary<int, double> Grades { get; set; } = new Dictionary<int, double>();

    }
}
