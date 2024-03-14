using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels.DbHelper;

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
        [Route("SemesterController/FinishedCurrentSemester")]
        [HttpGet]
        public object FinishedCurrentSemester()
        {
            return SemesterManager.FinishedCurrentSemester();
        }
        [Route("SemesterController/GetSemestersBySchoolYearId")]
        [HttpGet]
        public List<Semester> GetSemestersBySchoolYearId(int schoolYearId)
        {
            return SemesterManager.GetSemestersBySchoolYearId(schoolYearId);
        }
        [Route("SemesterController/StartNewSemesterInCurrentSchoolYear")]
        [HttpGet]
        public object StartNewSemesterInCurrentSchoolYear(string semesterName)
        {
            return SemesterManager.StartNewSemesterInCurrentSchoolYear(semesterName);
        }
    }
}
