using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class MassegeController : ControllerBase
    {
        [Route("MassegeController/InsertMassege")]
        [HttpPost]
        public int InsertMassege([FromBody] Massege massege)
        {
            return MassegeManager.InsertMassege(massege);
        }
        [Route("MassegeController/UpdateMassege")]
        [HttpPost]
        public int UpdateMassege([FromBody] Massege massege)
        {
            return MassegeManager.UpdateMassege(massege);
        }
        [Route("MassegeController/DeleteMassege")]
        [HttpPost]
        public int DeleteMassege([FromBody] Massege massege)
        {
            return MassegeManager.DeleteMassege(massege);
        }
        [Route("MassegeController/GetMasseges")]
        [HttpGet]
        public List<Massege> GetMasseges()
        {
            return MassegeManager.GetMasseges();
        }
        [Route("MassegeController/GetMassegeById")]
        [HttpGet]
        public Massege GetMassegeById(int id)
        {
            return MassegeManager.GetMassegeById(id);
        }
    }
}
