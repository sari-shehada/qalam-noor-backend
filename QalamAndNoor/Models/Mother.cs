using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Mother
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public bool DoesLiveWithHasband { get; set; }
        public string Career { get; set; } = string.Empty;
        public string TieNumber { get; set; } = string.Empty;
        public string TiePlace { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public ReligionEnum Religion { get; set; }
        public EducationalStatusEnum EducationalStatus { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;



    }
}
