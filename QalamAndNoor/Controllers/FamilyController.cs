using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class FamilyController : ControllerBase

    {
        [Route("FamilyController/InsertFamily")]
        [HttpPost]
        public int InsertFamily([FromBody]Family family)
        {
            return FamilyManager.InsertFamily(family);
        }
        [Route("FamilyController/UpdateFamily")]
        [HttpPost]
        public int UpdateFamily([FromBody] Family family)
        {
            return FamilyManager.UpdateFamily(family);
        }
        [Route("FamilyController/DeleteFamily")]
        [HttpPost]
        public int DeleteFamily([FromBody] Family family)
        {
            return FamilyManager.DeleteFamily(family);
        }
        [Route("FamilyController/GetFamilies")]
        [HttpGet]
        public List<Family> GetFamilies()
        {
            return FamilyManager.GetFamilies();
        }
        [Route("FamilyController/GetFamilyById")]
        [HttpGet]
        public Family GetFamilyById([FromQuery]int id)
        {
            return FamilyManager.GetFamilyById(id);
        }
        [Route("FamilyController/GetFamiliesByFatherTieNumber")]
        [HttpGet]
        public List<Family> GetFamiliesByFatherTieNumber([FromQuery] string tieNumber)
        {
            return FamilyManager.GetFamiliesByFatherTieNumber(tieNumber);
        }
    }
}
