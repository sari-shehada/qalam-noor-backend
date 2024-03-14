using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Controllers
{
    public class IlnessController : ControllerBase
    {
        [Route("IlnessController/InsertIlness")]
        [HttpPost]
        public int InsertIlness([FromBody] Ilness ilness)
        {
            return IlnessManager.InsertIlness(ilness);
        }
        [Route("IlnessController/UpdateIlness")]
        [HttpPost]
        public int UpdateIlness([FromBody] Ilness ilness)
        {
            return IlnessManager.UpdateIlness(ilness);
        }
        [Route("IlnessController/DeleteIlness")]
        [HttpPost]
        public int DeleteIlness([FromBody] Ilness ilness)
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
        [Route("IlnessController/GetStudentIllnessesByStudentId")]
        [HttpGet]
        public List<StudentIllnesses> GetStudentIllnessesByStudentId(int studentId)
        {
            return StudentIllnessesDataManager.GetStudentIllnessesByStudentId(studentId);
        }
    }
}
