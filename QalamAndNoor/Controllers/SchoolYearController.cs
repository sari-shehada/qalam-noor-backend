using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class SchoolYearController : ControllerBase
    {
        [Route("SchoolYearController/InsertSchoolYear")]
        [HttpPost]
        public object InsertSchoolYear([FromBody]SchoolYear schoolYear)

        {
            return SchoolYearManager.InsertSchoolYear(schoolYear);
        }
        [Route("SchoolYearController/UpdateSchoolYear")]
        [HttpPost]
        public int UpdateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            return SchoolYearManager.UpdateSchoolYear(schoolYear);
        }
        [Route("SchoolYearController/DeleteSchoolYear")]
        [HttpPost]
        public int DeleteSchoolYear([FromBody] SchoolYear schoolYear)
        {
            return SchoolYearManager.DeleteSchoolYear(schoolYear);
        }
        [Route("SchoolYearController/GetSchoolYears")]
        [HttpGet]
        public List<SchoolYear> GetSchoolYears()
        {
            return SchoolYearManager.GetSchoolYears();
        }
        [Route("SchoolYearController/GetSchoolYearById")]
        [HttpGet]
        public SchoolYear GetSchoolYearById(int id)
        {
            return SchoolYearManager.GetSchoolYearById(id);
        }
        [Route("SchoolYearController/GetCurrentSchoolYear")]
        [HttpGet]
        public SchoolYear GetCurrentSchoolYear()

        {
            return SchoolYearManager.GetCurrentSchoolYear();
        }
        [Route("SchoolYearController/EndingCurrentScoolYear")]
        [HttpGet]
        public object FinshedCurrentScoolYear()
        {
            return SchoolYearManager.FinshedCurrentScoolYear();
        }


    }
}
