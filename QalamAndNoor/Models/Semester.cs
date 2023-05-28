using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Semester
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SchoolYearId { get; set; }
        public bool IsDone { get; set; }
        public int? PreviousSemesterId { get; set; }
    }
}
