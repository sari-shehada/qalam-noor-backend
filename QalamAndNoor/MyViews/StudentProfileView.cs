using QalamAndNoor.Shared;

namespace QalamAndNoor.MyViews
{
    public class StudentProfileView
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = string.Empty;
        public DateTime StudentDateOfBirth { get; set; }
        public string StudentPlaceOfBirth { get; set; } = string.Empty;
        public bool Gender { get; set; }
        public string IncidentNumber { get; set; } = string.Empty;
        public string IncidentDate { get; set; } = string.Empty;
        public int PublicRecordId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string WhatsappPhoneNumber { get; set; } = string.Empty;
        public string LandLine { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public ReligionEnum StudentReligion { get; set; }
        //.............................................
        public string FatherFirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string GrandFatherName { get; set; } = string.Empty;
        public string GrandMotherName { get; set; } = string.Empty;
        public string FatherCareer { get; set; } = string.Empty;
        public string FatherPlaceOfResidence { get; set; } = string.Empty;
        public string FatherTieNumber { get; set; } = string.Empty;
        public string FatherTiePlace { get; set; } = string.Empty;
        public string FatherPlaceOfBirth { get; set; } = string.Empty;
        public ReligionEnum FatherReligion { get; set; }
        public string FatherCivilRegisterSecretary { get; set; } = string.Empty;
        public EducationalStatusEnum EducationalStatus { get; set; }
        public string FatherPhoneNumber { get; set; } = string.Empty;
        public string FatherPermenantAddress { get; set; } = string.Empty;
        //.............................
        public string MotherName { get; set; } = string.Empty;      
        public string MotherLastName { get; set; } = string.Empty;
        public string MotherFatherName { get; set; } = string.Empty;    
        public string MotherMotherName { get; set; } = string.Empty;
        public bool MotherDoesLiveWithHasband { get; set; }
        public string MotherCareer { get; set; } = string.Empty;
        public string MotherTieNumber { get; set; } = string.Empty;
        public string MotherTiePlace { get; set; } = string.Empty;
        public string MotherPlaceOfBirth { get; set; } = string.Empty;
        public DateTime MotherDateOfBirth { get; set; }
        public ReligionEnum MotherReligion { get; set; }
        public EducationalStatusEnum MotherEducationalStatus { get; set; }
        public string MotherPhoneNumber { get; set; } = string.Empty;
        //....................
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //......................
        public string AddressName { get; set; } = string.Empty;
        public string AddressDetails { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
    }

}
