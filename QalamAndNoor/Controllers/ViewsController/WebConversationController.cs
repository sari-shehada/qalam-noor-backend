using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager.ViewsManager;
using QalamAndNoor.Models.HelperModels;
using QalamAndNoor.MyViews;

namespace QalamAndNoor.Controllers.ViewsController
{
    public class WebConversationController : ControllerBase
    {
        [Route("WebConversationController/GetWebConversations")]
        [HttpGet]
        public List<WebConversation> GetWebConversations()
        {
            return WebConversationManager.GetWebConversations();
        }
        [Route("WebConversationController/GetOpenWebConversations")]
        [HttpGet]
        public List<WebConversation> GetOpenWebConversations()
        {
            return WebConversationManager.GetOpenWebConversations();
        }
        [Route("WebConversationController/GetClosedWebConversations")]
        [HttpGet]
        public List<WebConversation> GetClosedWebConversations()
        {
            return WebConversationManager.GetClosedWebConversations();
        }
    }
}
