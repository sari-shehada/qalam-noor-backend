using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class ClassRoomSchoolYearController : ControllerBase
    {
        [Route("ClassRoomSchoolYearController/InsertClassRoomSchoolYear")]
        [HttpPost]
        public int InsertClassRoomSchoolYear([FromBody] ClassRoomSchoolYear classRoomSchoolYear)
        {
            return ClassRoomSchoolYearManager.InsertClassRoomSchoolYear(classRoomSchoolYear);
        }
        [Route("ClassRoomSchoolYearController/UpdateClassRoomSchoolYear")]
        [HttpPost]
        public int UpdateClassRoomSchoolYear([FromBody] ClassRoomSchoolYear classRoomSchoolYear)
        {
            return ClassRoomSchoolYearManager.UpdateClassRoomSchoolYear(classRoomSchoolYear);
        }
        [Route("ClassRoomSchoolYearController/DeleteClassRoomSchoolYear")]
        [HttpPost]
        public int DeleteClassRoomSchoolYear([FromBody] ClassRoomSchoolYear classRoomSchoolYear)
        {
            return ClassRoomSchoolYearManager.DeleteClassRoomSchoolYear(classRoomSchoolYear);
        }
        [Route("ClassRoomSchoolYearController/GetClassRoomSchoolYears")]
        [HttpGet]
        public List<ClassRoomSchoolYear> GetClassRoomSchoolYears( )
        {
            return ClassRoomSchoolYearManager.GetClassRoomSchoolYears();
        }
        [Route("ClassRoomSchoolYearController/GetClassRoomSchoolYearById")]
        [HttpGet]
        public ClassRoomSchoolYear GetClassRoomSchoolYearById(int id)
        {
            return ClassRoomSchoolYearManager.GetClassRoomSchoolYearById(id);
        }
        [Route("ClassRoomSchoolYearController/GetClassRoomSchoolYearsBySchoolYearId")]
        [HttpGet]
        public List< ClassRoomSchoolYear> GetClassRoomSchoolYearsBySchoolYearId(int schoolYearId)
        {
            return ClassRoomSchoolYearManager.GetClassRoomSchoolYearsBySchoolYearId(schoolYearId);
        }
        [Route("ClassRoomSchoolYearController/GetClassRoomSchoolYearsByClassRoomId")]
        [HttpGet]
        public List<ClassRoomSchoolYear> GetClassRoomSchoolYearsByClassRoomId(int classRoomId)
        {
            return ClassRoomSchoolYearManager.GetClassRoomSchoolYearsByClassRoomId(classRoomId);
        }
    }
}
