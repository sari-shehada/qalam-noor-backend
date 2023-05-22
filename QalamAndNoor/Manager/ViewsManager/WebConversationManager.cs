using QalamAndNoor.DataManager.ViewsDataManager;
using QalamAndNoor.Models.HelperModels;
using QalamAndNoor.Shared;

namespace QalamAndNoor.Manager.ViewsManager
{
    public abstract class WebConversationManager
    {
        public static List<WebConversation> GetWebConversations()
        {
            return WebConversationViewDataManager.GetWebConversations();
        }
        public static List<WebConversation> GetOpenWebConversations()
        {
            List<WebConversation> webConversations = GetWebConversations();
            List<WebConversation> result = new List<WebConversation>();
            foreach (WebConversation webConversation in webConversations)
            {
                if (webConversation.Status== ConversationStatusEnum.Open)
                {
                    result.Add(webConversation);
                }
            }
            return result;
        }
        public static List<WebConversation> GetClosedWebConversations()
        {
            List<WebConversation> webConversations = GetWebConversations();
            List<WebConversation> result = new List<WebConversation>();
            foreach (WebConversation webConversation in webConversations)
            {
                if (webConversation.Status == ConversationStatusEnum.Closed)
                {
                    result.Add(webConversation);
                }
            }
            return result;
        }
    }
}
