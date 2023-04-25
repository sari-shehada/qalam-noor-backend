using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;

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
    }
}
