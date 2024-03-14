using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class ClassRoomController : ControllerBase
    {
        [Route("ClassRoomController/InsertClassRoom")]
        [HttpPost]
        public int InsertClassRoom([FromBody] ClassRoom classRoom)
        {
            return ClassRoomManager.InsertClassRoom(classRoom);
        }
        [Route("ClassRoomController/UpdateClassRoom")]
        [HttpPost]
        public int UpdateClassRoom([FromBody] ClassRoom classRoom)
        {
            return ClassRoomManager.UpdateClassRoom(classRoom);
        }
        [Route("ClassRoomController/DeleteClassRoom")]
        [HttpPost]
        public int DeleteClassRoom([FromBody] ClassRoom classRoom)
        {
            return ClassRoomManager.DeleteClassRoom(classRoom);
        }


        [Route("ClassRoomController/GetClasseRooms")]
        [HttpGet]
        public List<ClassRoom> GetClasseRooms()
        {
            return ClassRoomManager.GetClassRooms();
        }
        [Route("ClassRoomController/GetClassRoomById")]
        [HttpGet]
        public ClassRoom? GetClassRoomById(int id)
        {
            return ClassRoomManager.GetClassRoomById(id);
        }
        [Route("ClassRoomController/GetClassRoomsByName")]
        [HttpGet]
        public List<ClassRoom> GetClassRoomsByName(string name)
        {
            return ClassRoomManager.GetClassRoomsByName(name);
        }
        [Route("ClassRoomController/GetClassRoomsByClassId")]
        [HttpGet]
        public List<ClassRoom> GetClassRoomsByClassId(int classId)
        {
            return ClassRoomManager.GetClassRoomsByClassId(classId);
        }
        [Route("ClassRoomController/GetAvailableClassRoomsByClassId")]
        [HttpGet]
        public List<ClassRoom> GetAvailableClassRoomsByClassId(int classId)
        {
            return ClassRoomManager.GetAvailableClassRoomsByClassId(classId);
        }
        [Route("ClassRoomController/GetAlreadyOpenClassRoomsByClassId")]
        [HttpGet]
        public List<ClassRoom> GetAlreadyOpenClassRoomsByClassId(int classId)
        {
            return ClassRoomManager.GetAlreadyOpenClassRoomsByClassId(classId);
        }
        [Route("ClassRoomController/GetClassRoomsInCurrentSchoolYear")]
        [HttpGet]
        public List<ClassRoom> GetClassRoomsInCurrentSchoolYear()
        {
            return ClassRoomManager.GetClassRoomsInCurrentSchoolYear();
        }
        [Route("ClassRoomController/GetClassRoomsCountInCurrentSchoolYear")]
        [HttpGet]
        public int GetClassRoomsCountInCurrentSchoolYear()
        {
            return ClassRoomManager.GetClassRoomsCountInCurrentSchoolYear();
        }
        [Route("ClassRoomController/GetClassRoomsCountBySchoolYearId")]
        [HttpGet]
        public int GetClassRoomsCountBySchoolYearId(int schoolYearId)
        {
            return ClassRoomManager.GetClassRoomsBySchoolYearId(schoolYearId).Count;
        }
    }
}
