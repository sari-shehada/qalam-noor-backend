using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class SemesterYearRecordController : ControllerBase
    {
        [Route("SemesterYearRecordController/InsertSemsterYearRecord")]
        [HttpPost]
        public int InsertSemesterYearRecord([FromBody]SemesterYearRecord semesterYearRecord)
        {
            return SemesterYearRecordManager.InsertSemsterYearRecord(semesterYearRecord);
        }
        [Route("SemesterYearRecordController/UpdateSemesterYearRecord")]
        [HttpPost]
        public int UpdateSemesterYearRecord([FromBody] SemesterYearRecord semesterYearRecord)
        {
            return SemesterYearRecordManager.UpdateSemesterYearRecord(semesterYearRecord);
        }
        [Route("SemesterYearRecordController/DeleteSemesterYearRecord")]
        [HttpPost]
        public int DeleteSemesterYearRecord([FromBody] SemesterYearRecord semesterYearRecord)
        {
            return SemesterYearRecordManager.DeleteSemesterYearRecord(semesterYearRecord);
        }
        [Route("SemesterYearRecordController/GetSemesterYearRecords")]
        [HttpGet]
        public List<SemesterYearRecord> GetSemesterYearRecords()
        {
            return SemesterYearRecordManager.GetSemesterYearRecords();
        }

    }
}
