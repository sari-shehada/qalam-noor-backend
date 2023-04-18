using Microsoft.AspNetCore.Mvc;
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

    }
}
