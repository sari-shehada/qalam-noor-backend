using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.Manager;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Controllers
{
    public class statisticsController : ControllerBase
    {
        [Route("statisticsController/GetStatistics")]
        [HttpGet]
        public Dictionary<string, int> GetStatistics()
        {
            return StatisticsManager.GetStatistics();
        }
        [Route("statisticsController/GetPsychologicalStatusStudentCount")]
        [HttpGet]
        public List<PsychologicalStatusStudentCount> GetPsychologicalStatusStudentCount()
        {
            return PsychologicalStatusStudentCountDataManager.GetPsychologicalStatusStudentCount();
        }
        [Route("statisticsController/GetPsychologicalStatusMaleStudentCount")]
        [HttpGet]
        public List<PsychologicalStatusStudentCount> GetPsychologicalStatusMaleStudentCount()
        {
            return PsychologicalStatusStudentCountDataManager.GetPsychologicalStatusMaleStudentCount();
        }
        [Route("statisticsController/GetPsychologicalStatusFemaleStudentCount")]
        [HttpGet]
        public List<PsychologicalStatusStudentCount> GetPsychologicalStatusFemaleStudentCount()
        {
            return PsychologicalStatusStudentCountDataManager.GetPsychologicalStatusFemaleStudentCount();
        }
    }
}
