namespace QalamAndNoor.Models
{
    public class Family
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
        public int? ResponsiblePersonId { get; set; }
    }
}
