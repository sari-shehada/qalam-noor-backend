using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class MassegeController : ControllerBase
    {
        [Route("MassegeController/InsertMassege")]
        [HttpPost]
        public int InsertMassege([FromBody] Message massege)
        {
            return MassegeManager.InsertMassege(massege);
        }
        [Route("MassegeController/UpdateMassege")]
        [HttpPost]
        public int UpdateMassege([FromBody] Message massege)
        {
            return MassegeManager.UpdateMassege(massege);
        }
        [Route("MassegeController/DeleteMassege")]
        [HttpPost]
        public int DeleteMassege([FromBody] Message massege)
        {
            return MassegeManager.DeleteMassege(massege);
        }
        [Route("MassegeController/GetMasseges")]
        [HttpGet]
        public List<Message> GetMasseges()
        {
            return MassegeManager.GetMasseges();
        }
        [Route("MassegeController/GetMassegeById")]
        [HttpGet]
        public Message GetMassegeById(int id)
        {
            return MassegeManager.GetMassegeById(id);
        }
        
        [Route("MassegeController/GetMessagesByConversationID")]
        [HttpGet]
        public List<Message> GetMessagesByConversationID(int conversationId)
        {
            return MassegeManager.GetMessagesByConversationID(conversationId);
        }
        [Route("MassegeController/DeleteAllMassege")]
        [HttpGet]
        public int DeleteAllMassege()
        {
            return MassegeManager.DeleteAllMassege();
        }
    }
}
