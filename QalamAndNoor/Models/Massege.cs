using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Body { get; set; } = string.Empty;
        public int ConversationId { get; set; }
        public MessageSenderEnum Sender { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}

