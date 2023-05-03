namespace QalamAndNoor.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public int? NumberOfChildren { get; set; }
        public int AddressId { get; set; }
        public int JobTitleId { get; set; }
        public bool IsMale { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
