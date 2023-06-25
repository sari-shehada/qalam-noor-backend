namespace QalamAndNoor.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double TotalGrade { get; set; }
        public int TeacherId { get; set; }
        public bool IsEnriching { get; set; }
        public int ClassId { get; set; }
        public bool RequiredToPass { get; set; }
        public double RequiredGradeToPass { get; set; }
    }
}
