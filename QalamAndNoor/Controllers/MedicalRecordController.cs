using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class MedicalRecordController : ControllerBase
    {
        [Route("MedicalRecordController/InsertMedicalRecord")]
        [HttpPost]
        public int InsertMedicalRecord(MedicalRecord medicalRecord)
        {
            return MedicalRecordManager.InsertMedicalRecord(medicalRecord);
        }
        [Route("MedicalRecordController/UpdateMedicalRecord")]
        [HttpPost]
        public int UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            return MedicalRecordManager.UpdateMedicalRecord(medicalRecord);
        }
        [Route("MedicalRecordController/DeleteMedicalRecord")]
        [HttpPost]
        public int DeleteMedicalRecord(MedicalRecord medicalRecord)
        {
            return MedicalRecordManager.DeleteMedicalRecord(medicalRecord);
        }
        [Route("MedicalRecordController/GetMedicalRecords")]
        [HttpGet]
        public List<MedicalRecord> GetMedicalRecords()
        {
            return MedicalRecordManager.GetMedicalRecords();
        }
        [Route("MedicalRecordController/GetMedicalRecordById")]
        [HttpGet]
        public MedicalRecord GetMedicalRecordById(int id)
        {
            return MedicalRecordManager.GetMedicalRecordById(id);
        }
    }
}

