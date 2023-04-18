using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class MotherController : ControllerBase
    {
        [Route("MotherController/InsertMother")]
        [HttpPost]

        public int InsertMother([FromBody] Mother mother)
        {
            return MotherManager.InsertMother(mother);
        }
        [Route("MotherController/UpdateMother")]
        [HttpPost]
        public int UpdateMother([FromBody] Mother mother)
        {
            return MotherManager.UpdateMother(mother);
        }
        [Route("MotherController/DeleteMother")]
        [HttpPost]
        public int DeleteMother([FromBody] Mother mother)
        {
            return MotherManager.DeleteMother(mother);
        }
        [Route("MotherController/GetMothers")]
        [HttpGet]
        public List<Mother> GetMothers()
        {
            return MotherManager.GetMothers();
        }
        [Route("MotherController/GetMotherById")]
        [HttpGet]
        public Mother GetMotherById(int id)
        {
            return MotherManager.GetMotherById(id);
        }
    }
}
