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
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public int PublicRecordId { get; set; }
    }
}
