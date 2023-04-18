using QalamAndNoor.Shared;

namespace QalamAndNoor.Models
{
    public class Conversation
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public ConversationStatusEnum Status { get; set; }
        
        //TODO: Check Naming With DB 
        public ConversationPartyEnum OrginalIssuer { get; set; } 
    }
}
