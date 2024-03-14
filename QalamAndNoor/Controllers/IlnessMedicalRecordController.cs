using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class IlnessMedicalRecordController : ControllerBase
    {
        [Route("IlnessMedicalRecordController/InsertIlnessMedicalRecords")]
        [HttpPost]
        public int InsertIlnessMedicalRecord([FromBody] IlnessMedicalRecord ilnessMedicalRecord)
        {
            return IlnessMedicalRecordManager.InsertIlnessMedicalRecords(ilnessMedicalRecord);
        }
        [Route("IlnessMedicalRecordController/UpdateIlnessMedicalRecord")]
        [HttpPost]
        public int UpdateIlnessMedicalRecord([FromBody] IlnessMedicalRecord ilnessMedicalRecord)
        {
            return IlnessMedicalRecordManager.UpdateIlnessMedicalRecord(ilnessMedicalRecord);
        }
        [Route("IlnessMedicalRecordController/DeleteIlnessMedicalRecord")]
        [HttpPost]
        public int DeleteIlnessMedicalRecord([FromBody] IlnessMedicalRecord ilnessMedicalRecord)
        {
            return IlnessMedicalRecordManager.DeleteIlnessMedicalRecord(ilnessMedicalRecord);
        }
        [Route("IlnessMedicalRecordController/GetIlnessMedicalRecords")]
        [HttpGet]
        public List<IlnessMedicalRecord> GetIlnessMedicalRecords()
        {
            return IlnessMedicalRecordManager.GetIlnessMedicalRecords();
        }
        [Route("IlnessMedicalRecordController/GetIlnessMedicalRecordById")]
        [HttpGet]
        public IlnessMedicalRecord GetIlnessMedicalRecordById(int id)
        {
            return IlnessMedicalRecordManager.GetIlnessMedicalRecordById(id);
        }
    }
}
