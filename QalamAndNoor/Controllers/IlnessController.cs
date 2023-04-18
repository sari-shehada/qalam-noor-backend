using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class IlnessController : ControllerBase
    {
        [Route("IlnessController/InsertIlness")]
        [HttpPost]
        public int InsertIlness(Ilness ilness)
        {
            return IlnessManager.InsertIlness(ilness);
        }
        [Route("IlnessController/UpdateIlness")]
        [HttpPost]
        public int UpdateIlness(Ilness ilness)
        {
            return IlnessManager.UpdateIlness(ilness);
        }
        [Route("IlnessController/DeleteIlness")]
        [HttpPost]
        public int DeleteIlness(Ilness ilness)
        {
            return IlnessManager.DeleteIlness(ilness);
        }
        [Route("IlnessController/GetIlnesses")]
        [HttpGet]
        public List<Ilness> GetIlnesses()
        {
            return IlnessManager.GetIlnesses();
        }
        [Route("IlnessController/GetIlnessById")]
        [HttpGet]
        public Ilness GetIlnessById(int id)
        {
            return IlnessManager.GetIlnessById(id);
        }
    }
}
