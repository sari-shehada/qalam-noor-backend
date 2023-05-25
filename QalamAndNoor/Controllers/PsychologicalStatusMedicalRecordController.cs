using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class PsychologicalStatusMedicalRecordController : ControllerBase
    {
        [Route("PsychologicalStatusMedicalRecordController/InsertPsychologicalStatusMedicalRecord")]
        [HttpPost]
        public int InsertPsychologicalStatusMedicalRecord([FromBody] PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord)
        {
            return PsychologicalStatusMedicalRecordManager.InsertPsychologicalStatusMedicalRecord(psychologicalStatusMedicalRecord);
        }
        [Route("PsychologicalStatusMedicalRecordController/UpdatePsychologicalStatusMedicalRecord")]
        [HttpPost]
        public int UpdatePsychologicalStatusMedicalRecord([FromBody] PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord)
        {
            return PsychologicalStatusMedicalRecordManager.UpdatePsychologicalStatusMedicalRecord(psychologicalStatusMedicalRecord);
        }
        [Route("PsychologicalStatusMedicalRecordController/DeletePsychologicalStatusMedicalRecord")]
        [HttpPost]
        public int DeletePsychologicalStatusMedicalRecord([FromBody] PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord)
        {
            return PsychologicalStatusMedicalRecordManager.DeletePsychologicalStatusMedicalRecord(psychologicalStatusMedicalRecord);
        }
        [Route("PsychologicalStatusMedicalRecordController/GetPsychologicalStatusMedicalRecords")]
        [HttpGet] 
        public List<PsychologicalStatusMedicalRecord> GetPsychologicalStatusMedicalRecords()
        {
            return PsychologicalStatusMedicalRecordManager.GetPsychologicalStatusMedicalRecords();
        }
        [Route("PsychologicalStatusMedicalRecordController/GetPsychologicalStatusMedicalRecordById")]
        [HttpGet]
        public PsychologicalStatusMedicalRecord GetPsychologicalStatusMedicalRecordById(int id)
        {
            return PsychologicalStatusMedicalRecordManager.GetPsychologicalStatusMedicalRecordById(id);
        }
        [Route("PsychologicalStatusMedicalRecordController/GetPsychologicalStatusMedicalRecordsByMedicalRecordId")]
        [HttpGet]
        public List<PsychologicalStatusMedicalRecord> GetPsychologicalStatusMedicalRecordsByMedicalRecordId(int medicalRecordId)
        {
            return PsychologicalStatusMedicalRecordManager.GetPsychologicalStatusMedicalRecordsByMedicalRecordId(medicalRecordId);
        }
    }
}
