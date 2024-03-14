using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Controllers
{
    public class VaccineController : ControllerBase
    {
        [Route("VaccineController/InsertVaccine")]
        [HttpPost]

        public int InsertVaccine([FromBody] Vaccine vaccine)
        {
            return VaccineManager.InsertVaccine(vaccine);
        }
        [Route("VaccineController/UpdateVaccine")]
        [HttpPost]

        public int UpdateVaccine([FromBody] Vaccine vaccine)
        {
            return VaccineManager.UpdateVaccine(vaccine);
        }
        [Route("VaccineController/DeleteVaccine")]
        [HttpPost]

        public int DeleteVaccine([FromBody] Vaccine vaccine)
        {
            return VaccineManager.DeleteVaccine(vaccine);
        }
        [Route("VaccineController/GetVaccines")]
        [HttpGet]
        public List<Vaccine> GetVaccines()
        {
            return VaccineManager.GetVaccines();
        }
        [Route("VaccineController/GetVaccineById")]
        [HttpGet]
        public Vaccine GetVaccineById(int id)
        {
            return VaccineManager.GetVaccineById(id);
        }
        [Route("VaccineController/GetTakenVaccinesByStudentId")]
        [HttpGet]
        public List<Vaccine> GetTakenVaccinesByStudentId(int studentId)
        {
            return VaccineManager.GetTakenVaccinesByStudentId(studentId);
        }
        [Route("VaccineController/GetStudentTakenVaccinesByStudentId")]
        [HttpGet]
        public List<StudentTakenVaccine> GetStudentTakenVaccinesByStudentId(int studentId)
        {
            return StudentTakenVaccineDataManager.GetStudentTakenVaccinesByStudentId(studentId);
        }


    }
}
