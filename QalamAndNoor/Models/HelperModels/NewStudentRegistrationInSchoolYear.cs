namespace QalamAndNoor.Models.HelperModels
{
    public class NewStudentRegistrationInSchoolYear
    {
        public int ClassRoomId { get; set; }
        public List<int> YearRecordId { get; set; } = new List<int>();
        public int SemesterId { get; set; }
    }
}
