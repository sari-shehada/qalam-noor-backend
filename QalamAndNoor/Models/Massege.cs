using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Massege
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public MassegeSenderEnum Sender { get; set; }
        public int Sequence { get; set; }
        public DateTime Date { get; set; }
        public int ConversationId { get; set; }
    }
}
