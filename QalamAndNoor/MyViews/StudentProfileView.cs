using QalamAndNoor.Shared;

namespace QalamAndNoor.MyViews
{
    public class StudentProfileView
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = string.Empty;
        public DateTime StudentDateOfBirth { get; set; }
        public string StudentPlaceOfBirth { get; set; }
        public bool Gender { get; set; }
        public string IncidentNumber { get; set; }
        public string IncidentDate { get; set; }
        public int PublicRecordId { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappPhoneNumber { get; set; }
        public string LandLine { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public ReligionEnum StudentReligion { get; set; }
        //.............................................
        public string FatherFirstName { get; set; }
        public string LastName { get; set; }
        public string GrandFatherName { get; set; }
        public string GrandMotherName { get; set; }
        public string FatherCareer { get; set; }
        public string FatherPlaceOfResidence { get; set; }
        public string FatherTieNumber { get; set; }
        public string FatherTiePlace { get; set; }
        public string FatherPlaceOfBirth { get; set; }
        public ReligionEnum FatherReligion { get; set; }
        public string FatherCivilRegisterSecretary { get; set; }
        public EducationalStatusEnum EducationalStatus { get; set; }
        public string FatherPhoneNumber { get; set; }
        public string FatherPermenantAddress { get; set; }
        //.............................
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherFatherName { get; set; }
        public string MotherMotherName { get; set; }
        public bool MotherDoesLiveWithHasband { get; set; }
        public string MotherCareer { get; set; }
        public string MotherTieNumber { get; set; }
        public string MotherTiePlace { get; set; }
        public string MotherPlaceOfBirth { get; set; }
        public DateTime MotherDateOfBirth { get; set; }
        public ReligionEnum MotherReligion { get; set; }
        public EducationalStatusEnum MotherEducationalStatus { get; set; }
        public string MotherPhoneNumber { get; set; }
        //....................
        public string UserName { get; set; }
        public string Password { get; set; }
        //......................
        public string AddressName { get; set; }
        public string AddressDetails { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }
    }

}
