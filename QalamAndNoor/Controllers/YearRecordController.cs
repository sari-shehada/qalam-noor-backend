using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class YearRecordController : Controller
    {
        [Route("YearRecordController/InsertYearRecord")]
        [HttpPost]
        public int InsertYearRecord([FromBody] YearRecord record)
        {
            return YearRecordManager.InsertYearRecord(record);
        }
        [Route("YearRecordController/UpdateYearRecord")]
        [HttpPost]
        public int UpdateYearRecord([FromBody] YearRecord record)
        {
            return YearRecordManager.UpdateYearRecord(record);
        }
        [Route("YearRecordController/DeleteYearRecord")]
        [HttpPost]
        public int DeleteYearRecord([FromBody] YearRecord record)
        {
            return YearRecordManager.DeleteYearRecord(record);
        }
        [Route("YearRecordController/GetYearRecords")]
        [HttpGet]
        public List<YearRecord> GetYearRecords()
        {
            return YearRecordManager.GetYearRecords();
        }
        [Route("YearRecordController/GetYearRecordById")]
        [HttpGet]
        public YearRecord GetYearRecordById(int id)
        {
            return YearRecordManager.GetYearRecordById(id);
        }
        [Route("YearRecordController/GetYearRecordsBySchoolyearId")]
        [HttpGet]
        public List<YearRecord> GetYearRecordsBySchoolyearIdd(int schoolYearId)
        {
            return YearRecordManager.GetYearRecordsBySchoolyearId(schoolYearId);
        }
        [Route("YearRecordController/GetYearRecordsByClassRoomSchoolRearId")]
        [HttpGet]
        public List<YearRecord> GetYearRecordsByClassRoomSchoolRearId(int classRoomSchoolYearId)
        {
            return YearRecordManager.GetYearRecordsByClassRoomSchoolRearId(classRoomSchoolYearId);
        }

    }
}
