using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class PsychologicalStatusController : ControllerBase
    {
        [Route("PsychologicalStatusController/InsertPsychologicalStatus")]
        [HttpPost]
        public int InsertPsychologicalStatus([FromBody] PsychologicalStatus status)
        {
            return PsychologicalStatusManager.InsertPsychologicalStatus(status);
        }
        [Route("PsychologicalStatusController/UpdatePsychologicalStatus")]
        [HttpPost]
        public int UpdatePsychologicalStatus([FromBody] PsychologicalStatus status)
        {
            return PsychologicalStatusManager.UpdatePsychologicalStatus(status);
        }
        [Route("PsychologicalStatusController/DeletePsychologicalStatus")]
        [HttpPost]
        public int DeletePsychologicalStatus([FromBody] PsychologicalStatus status)

        {
            return PsychologicalStatusManager.DeletePsychologicalStatus(status);
        }
        [Route("PsychologicalStatusController/GetPsychologicalStatusess")]
        [HttpGet]
        public List<PsychologicalStatus> GetPsychologicalStatuses()

        {
            return PsychologicalStatusManager.GetPsychologicalStatuses();
        }
        [Route("PsychologicalStatusController/GetPsychologicalStatusById")]
        [HttpGet]

        public PsychologicalStatus GetPsychologicalStatusById(int id)
        {
            return PsychologicalStatusManager.GetPsychologicalStatusById(id);
        }
    }
}
