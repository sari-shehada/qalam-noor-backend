using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class ConversationController : ControllerBase
    {
        [Route("ConversationController/InsertConversation")]
        [HttpPost]
        public int InsertConversation([FromBody] Conversation conversation)
        {
            return ConversationManager.InsertConversation(conversation);
        }
        [Route("ConversationController/UpdateConversation")]
        [HttpPost]
        public int UpdateConversation([FromBody] Conversation conversation)
        {
            return ConversationManager.UpdateConversation(conversation);
        }
        [Route("ConversationController/DeleteConvesation")]
        [HttpPost]
        public int DeleteConvesation([FromBody] Conversation conversation)
        {
            return ConversationManager.DeleteConvesation(conversation);
        }
        [Route("ConversationController/GetConversations")]
        [HttpGet]
        public List<Conversation> GetConversations()
        {
            return ConversationManager.GetConversations();
        }
        [Route("ConversationController/GetConverstionById")]
        [HttpGet]
        public Conversation GetConversationById(int id)
        {
            return ConversationManager.GetConverstionById(id);
        }
        [Route("ConversationController/GetConversationsByStudentId")]
        [HttpGet]
        public List<Conversation> GetConversationsByStudentId(int studentId)
        {
            return ConversationManager.GetConversationsByStudentId(studentId);
        }
        [Route("ConversationController/DeleteAllConversation")]
        [HttpGet]
        public int DeleteAllConversation()
        {
            return ConversationsDataManager.DeleteAllConversation();
        }
    }
}
