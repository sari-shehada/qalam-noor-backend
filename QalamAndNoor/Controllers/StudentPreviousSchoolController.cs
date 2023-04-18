using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class StudentPreviousSchoolController : ControllerBase
    {
        [Route("StudentPreviousSchoolController/InsertStudentPreviousSchool")]
        [HttpPost]
        public int InsertStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            return StudentPreviousSchoolManager.InsertStudentPreviousSchool(studentPreviousSchool);
        }
        [Route("StudentPreviousSchoolController/UpdateStudentPreviousSchool")]
        [HttpPost]
        public int UpdateStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            return StudentPreviousSchoolManager.UpdateStudentPreviousSchool(studentPreviousSchool);
        }
        [Route("StudentPreviousSchoolController/DeleteStudentPreviousSchool")]
        [HttpPost]
        public int DeleteStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            return StudentPreviousSchoolManager.DeleteStudentPreviousSchool(studentPreviousSchool);
        }
        [Route("StudentPreviousSchoolController/GetStudentPreviousSchools")]
        [HttpGet]
        public List<StudentPreviousSchool> GetStudentPreviousSchools()
        {
            return StudentPreviousSchoolManager.GetStudentPreviousSchools();
        }
        [Route("StudentPreviousSchoolController/GetStudentPreviousSchoolById")]
        [HttpGet]
        public StudentPreviousSchool GetStudentPreviousSchoolById(int id)
        {
            return StudentPreviousSchoolManager.GetStudentPreviousSchoolById(id);
        }

    }
}
