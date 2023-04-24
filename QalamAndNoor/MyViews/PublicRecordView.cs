using QalamAndNoor.Models;
using System.Numerics;

namespace QalamAndNoor.MyViews
{
    public class PublicRecordView
    {
        public string StudentFirstName { get; set; }
        public string  FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string StudentLastName { get; set; }
        public string MotherName { get; set; }
        public bool StudentGender { get; set; }
        public string StudentPlaceOfBirth { get; set; }
        public DateTime StudentDateOfBirth { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentWhataappPhoneNumber { get; set; }
        public string StudentLandLine { get; set; }
        public string TieNumber { get; set; }
        public string TiePlace { get; set; }
     
        public string CityName { get; set; }
        public string AreaName { get; set; }
        public string AddressName { get; set; }

        public int ClassId { get; set; }

        public int PublicRecordId { get; set; }

    }
}
