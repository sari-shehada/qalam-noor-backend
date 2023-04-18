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
        public ClassRoom GetClassRoomById(int id)
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
    }
}
