using QalamAndNoor.Shared;

namespace QalamAndNoor.Models.HelperModels
{
    public class WebConversation
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public ConversationStatusEnum Status { get; set; }
        public ConversationPartyEnum OrginalIssuer { get; set; }
        public bool IsReadOther { get; set; }
        public bool IsReadParent { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public int PublicRecordId { get; set; }
    }
}
