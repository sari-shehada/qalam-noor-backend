using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class FatherController : ControllerBase
    {
        [Route("FatherController/InsertFather")]
        [HttpPost]
        public int InsertFather([FromBody]Father father)
        {
            return FatherManager.InsertFather(father);
        }
        [Route("FatherController/UpdateFather")]
        [HttpPost]
        public int UpdateFather([FromBody] Father father)
        {
            return FatherManager.UpdateFather(father);
        }
        [Route("FatherController/DeleteFather")]
        [HttpPost]
        public int DeleteFather([FromBody] Father father)
        {
            return FatherManager.DeleteFather(father);
        }
        [Route("FatherController/GetFathers")]
        [HttpGet]
        public List<Father> GetFathers()
        {
            return FatherManager.GetFathers();
        }
        [Route("FatherController/GetFatherById")]
        [HttpGet]
        public Father GetFatherById(int id)
        {
            return FatherManager.GetFatherById(id);
        }
        [Route("FatherController/GetFathersByTieNumber")]
        [HttpGet]
        public List<Father> GetFathersByTieNumber(string tieNumber)
        {
            return FatherManager.GetFathersByTieNumber(tieNumber);
        }

    }
}
