namespace QalamAndNoor.Models.HelperModels
{
    public class StudentInfo
    {
        public int StudentId { get; set; }
        public string SchoolYear { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public string ClassRoom { get; set; } = string.Empty;
    }
}
