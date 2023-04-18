using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class PreviousSchoolController : ControllerBase
    {
        [Route("PreviousSchoolController/InsertPreviousSchool")]
        [HttpPost]
        public int InsertPreviousSchool([FromBody] PreviousSchool previousSchool)
        {
            return PreviousSchoolManager.InsertPreviousSchool(previousSchool);
        }

        [Route("PreviousSchoolController/UpdatePreviousSchool")]
        [HttpPost]
        public int UpdatePreviousShcool([FromBody] PreviousSchool previousSchool)
        {
            return PreviousSchoolManager.UpdatePreviousSchool(previousSchool);
        }

        [Route("PreviousSchoolController/DeletePreviousSchool")]
        [HttpPost]
        public int DeletePreviousSchool([FromBody] PreviousSchool previousSchool)
        {
            return PreviousSchoolManager.DeletePreviousSchool(previousSchool);
        }
        [Route("PreviousSchoolController/GetPreviousSchools")]
        [HttpGet]
        public List<PreviousSchool> GetPreviousSchools()
        {
            return PreviousSchoolManager.GetPreviousSchools();
        }
        [Route("PreviousSchoolController/GetPreviousSchoolById")]
        [HttpGet]
        public PreviousSchool GetPreviousSchoolById(int id)
        {
            return PreviousSchoolManager.GetPreviousSchoolById(id);
        }


    }
}
