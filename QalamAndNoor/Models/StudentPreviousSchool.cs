namespace QalamAndNoor.Models
{
    public class StudentPreviousSchool
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int PreviousSchoolId { get; set; }
        public string? Note { get; set; }
    }
}
