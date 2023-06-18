using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class SemesterController : ControllerBase
    {
        [Route("SemesterController/InsertSemester")]
        [HttpPost]
        public int InsertSemester([FromBody] Semester semester)
        {
            return SemesterManager.InsertSemester(semester);
        }
        [Route("SemesterController/UpdateSemester")]
        [HttpPost]
        public int UpdateSemester([FromBody] Semester semester)
        {
            return SemesterManager.UpdateSemester(semester);
        }
        [Route("SemesterController/DeleteSemester")]
        [HttpPost]
        public int DeleteSemester([FromBody] Semester semester)
        {
            return SemesterManager.DeleteSemester(semester);
        }
        [Route("SemesterController/GetSemesters")]
        [HttpGet]
        public  List<Semester> GetSemesters()
        {
            return SemesterManager.GetSemesters();
        }
        [Route("SemesterController/GetSemesterById")]
        [HttpGet]
        public Semester GetSemesterById(int id)
        {
            return SemesterManager.GetSemesterById(id);
        }
        [Route("SemesterController/GetCurrentSemesterInCurrentSchoolYear")]
        [HttpGet]
        public Semester GetCurrentSemesterInCurrentSchoolYear()
        {
            return SemesterManager.GetCurrentSemesterInCurrentSchoolYear();
        }

    }
}
