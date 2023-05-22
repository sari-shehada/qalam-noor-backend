using QalamAndNoor.DataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Manager
{
    public abstract class ConversationManager
    {
        public static List<Conversation> GetConversations()
        {
            return ConversationsDataManager.GetConversations().ToList();
        }
        public static int InsertConversation(Conversation conversation)
        {
            return ConversationsDataManager.InsertConversation(conversation);
        }
        public static int UpdateConversation(Conversation conversation)
        {
            return ConversationsDataManager.UpdateConversation(conversation);
        }
        public static int DeleteConvesation(Conversation conversation)
        {
            return ConversationsDataManager.DeleteConversation(conversation);
        }
        public static Conversation? GetConverstionById(int id)
        {
            List<Conversation> conversations = GetConversations();
            foreach (Conversation conversation in conversations)
            {
                if (conversation.ID == id)
                {
                    return conversation;
                }
            }
            return null;
        }

        public static List<Conversation> GetConversationsByStudentId(int studentId)
        {
            List<Conversation> conversations = GetConversations();
            List<Conversation>result = new List<Conversation>();
            foreach (Conversation conversation in conversations)
            {
                if (conversation.StudentId==studentId)
                {
                    result.Add(conversation);
                }
            }
            return result;
        }

      

        
    }
}
