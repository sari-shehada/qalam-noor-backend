namespace QalamAndNoor.Models.HelperModels
{
    public class LateStudent

    {
        public int YearRecordId { get; set; }
        public int ClassRoomId { get; set; }
        public int CLassId { get; set; }
        public List<LateStudentEnrollmentSemesterResult> SemesterResults { get; set; } = new List<LateStudentEnrollmentSemesterResult>();


    }
}
