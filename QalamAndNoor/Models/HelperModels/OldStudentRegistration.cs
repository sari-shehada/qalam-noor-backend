namespace QalamAndNoor.Models.HelperModels
{
    public class OldStudentRegistration
    {
        public int ClassId { get; set; }
        public int ClassRoomId { get; set; }
        public List<int> StudentIds { get; set; }
        public int SemesterId { get; set; }
    }
}
