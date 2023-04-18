using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class AreaController : ControllerBase
    {
        [Route("AreaController/InsertArea")]
        [HttpPost]
        public int InsertArea([FromBody] Area area)
        {
            return AreaManager.InsertArea(area);
        }
        [Route("AreaController/UpdateArea")]
        [HttpPost]
        public int UpdateArea([FromBody] Area area)
        {
            return AreaManager.UpdateArea(area);
        }
        [Route("AreaController/DeleteArea")]
        [HttpPost]
        public int DeleteArea([FromBody] Area area)
        {
            return AreaManager.DeleteArea(area);
        }
        [Route("AreaController/GetAreas")]
        [HttpGet]
        public List<Area> GetAreas()
        {
            return AreaManager.GetAreas();
        }

        [Route("AreaController/GetAreaById")]
        [HttpGet]
        public Area GetAreaById(int id)
        {
            return AreaManager.GetAreaById(id);
        }
        [Route("AreaController/GetAreasByName")]
        [HttpGet]
        public List<Area> GetAreasByName(string name)
        {
            return AreaManager.GetAreasByName(name);
        }
        [Route("AreaController/GetAreasByCityId")]
        [HttpGet]
        public List<Area> GetAreasByCityId(int  cityId)
        {
            return AreaManager.GetAreasByCityId(cityId);
        }
    }
}
