using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Conversation
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public ConversationStatusEnum Status { get; set; }
        public ConversationPartyEnum OrginalIssuer { get; set; }
        public bool IsReadOther { get; set; }
        public bool IsReadParent { get; set; }
    }
}