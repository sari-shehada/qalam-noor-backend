using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public ReligionEnum Religion { get; set; }
        public string IncidentNumber { get; set; } = string.Empty;
        public string IncidentDate { get; set; } = string.Empty;
        public int PublicRecordId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string WhatsappPhoneNumber { get; set; } = string.Empty;
        public string LandLine { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public int AddressId { get; set; }
        public int FamilyId { get; set; }
        public bool? IsActive { get; set; }

    }
}
