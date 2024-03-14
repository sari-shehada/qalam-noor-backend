using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class CourseController : ControllerBase
    {
        [Route("CourseController/InsertCourse")]
        [HttpPost]
        public int InsertCourse([FromBody] Course course)
        {
            return CourseManager.InsertCourse(course);
        }
        [Route("CourseController/UpdateCourse")]
        [HttpPost]
        public int UpdateCourse([FromBody] Course course)
        {
            return CourseManager.UpdateCourse(course);
        }
        [Route("CourseController/DeleteCourse")]
        [HttpPost]
        public int DeleteCourse([FromBody] Course course)
        {
            return CourseManager.DeleteCourse(course);
        }
        [Route("CourseController/GetCourses")]
        [HttpGet]
        public List<Course> GetCourses()
        {
            return CourseManager.GetCourses();
        }
        [Route("CourseController/GetCourseById")]
        [HttpGet]
        public Course GetCourseById(int id)
        {
            return CourseManager.GetCourseById(id);
        }
        [Route("CourseController/GetCoursesByClassId")]
        [HttpGet]
        public List<Course> GetCoursesByClassId(int classId)
        {
            return CourseManager.GetCoursesByClassId(classId);
        }
        [Route("CourseController/GetCoursesByTeacherId")]
        [HttpGet]
        public List<Course> GetCoursesByTeacherId(int teacherId)
        {
            return CourseManager.GetCoursesByTeacherId(teacherId);
        }
        [Route("CourseController/UpdateAllCourses")]
        [HttpPost]
        public int UpdateAllCourses()
        {
            return CourseDataManager.UpdateAllCourses();
        }
        [Route("CourseController/IsOnlyDropByCourseId")]
        [HttpGet]
        public bool IsOnlyDropByCourseId(int courseId)
        {
            return CourseManager.IsOnlyDropByCourseId(courseId);
        }
        [Route("CourseController/GetRequiredToPassCourses")]
        [HttpGet]
        public List<Course> GetRequiredToPassCourses()
        {
            return CourseManager.GetRequiredToPassCurses();
        }


    }
}
