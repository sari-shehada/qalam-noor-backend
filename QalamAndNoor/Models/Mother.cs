using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Mother
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public bool DoesLiveWithHasband { get; set; }
        public string Career { get; set; }
        public string TieNumber { get; set; }
        public string TiePlace { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ReligionEnum Religion { get; set; }
        public EducationalStatusEnum EducationalStatus { get; set; }
        public string PhoneNumber { get; set; }



    }
}
