using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public ReligionEnum Religion { get; set; }
        public string IncidentNumber { get; set; }
        public string IncidentDate { get; set; }
        public int PublicRecordId { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappPhoneNumber { get; set; }
        public string LandLine { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public int AddressId { get; set; }
        public int FamilyId { get; set; }

    }
}
