using QalamAndNoor.Models;
using System.Numerics;

namespace QalamAndNoor.MyViews
{
    public class PublicRecordView
    {
        public string StudentFirstName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string GrandFatherName { get; set; } = string.Empty;
        public string StudentLastName { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public bool StudentGender { get; set; }
        public string StudentPlaceOfBirth { get; set; } = string.Empty;
        public DateTime StudentDateOfBirth { get; set; }
        public string StudentPhoneNumber { get; set; } = string.Empty;
        public string StudentWhataappPhoneNumber { get; set; } = string.Empty;
        public string StudentLandLine { get; set; } = string.Empty;
        public string TieNumber { get; set; } = string.Empty;
        public string TiePlace { get; set; } = string.Empty;
     
        public string CityName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty; 

        public int ClassId { get; set; }

        public int PublicRecordId { get; set; }

    }
}
