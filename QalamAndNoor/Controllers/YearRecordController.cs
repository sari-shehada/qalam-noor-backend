using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
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
        
        
        [Route("YearRecordController/GetYearRecordsByStudentId")]
        [HttpGet]
        public List<YearRecord> GetYearRecordsByStudentId(int studentId)
        {
            return YearRecordManager.GetYearRecordsByStudentId(studentId);
        }
        //[Route("YearRecordController/GetDidPassedYearRecordsByStudentId")]
        //[HttpGet]
        //public List<YearRecord> GetDidPassedYearRecordsByStudentId(int studentId)
        //{
        //    return YearRecordManager.GetDidPassedYearRecordsByStudentId(studentId);
        //}
        [Route("YearRecordController/UpdateNullCLassRoomSchoolYearYearRecord")]
        [HttpPost]
        public int UpdateNullCLassRoomSchoolYearYearRecord([FromBody] YearRecord record)
        {
            return YearRecordDataManager.UpdateNullCLassRoomSchoolYearYearRecord(record);
        }
        [Route("YearRecordController/GetYearRecordsInCurrentSchoolYear")]
        [HttpGet]
        public List<YearRecord> GetYearRecordsInCurrentSchoolYear()
        {
            return YearRecordManager.GetYearRecordsinCurrentSchoolYear();
        }

    }
}
