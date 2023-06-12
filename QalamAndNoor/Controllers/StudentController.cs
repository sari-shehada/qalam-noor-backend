using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
using QalamAndNoor.Manager;
using QalamAndNoor.Manager.ViewsManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Controllers
{
    public class StudentController : ControllerBase
    {

        [Route("StudentController/InsertStudent")]
        [HttpPost]
        public int InsertStudent([FromBody] Student student)
        {
            return StudentManager.InsertStudent(student);
        }
        [Route("StudentController/RegisterStudent")]
        [HttpPost]
        public object RegisterStudent([FromBody] StudentRegistrationModel registrationModel)
        {
            return StudentManager.RegisterStudent(registrationModel);
        }
        [Route("StudentController/UpdateStudent")]
        [HttpPost]
        public int UpdateStudent([FromBody] Student student)
        {
            return StudentManager.UpdateStudent(student);
        }
        [Route("StudentController/DeleteStudent")]
        [HttpPost]
        public int DeleteStudent([FromBody] Student student)
        {
            return StudentDataManager.DeleteStudent(student);
        }
        [Route("StudentController/GetStudents")]
        [HttpGet]
        public List<Student> GetStudents()
        {
            return StudentManager.GetStudents();
        }
        [Route("StudentController/GetStudentById")]
        [HttpGet]
        public Student GetStudentById(int id)
        {
            return StudentManager.GetStudentById(id);
        }
        [Route("StudentController/GetStudentByName")]
        [HttpGet]
        public List<Student> GetStudentByName(string name)
        {
            return StudentManager.GetStudentByName(name);
        }
        [Route("StudentController/GetMaleStudents")]
        [HttpGet]
        public List<Student> GetMaleStudents()
        {
            return StudentManager.GetStudentsByIsMale();
        }
        [Route("StudentController/GetFemaleStudents")]
        [HttpGet]
        public List<Student> GetFemaleStudents()
        {
            return StudentManager.GetStudentsByIsFemale();
        }
        [Route("StudentController/GetStudentsByFamilyId")]
        [HttpGet]
        public List<Student> GetStudentsByFamilyId(int familyId)
        {
            return StudentManager.GetStudentsByFamilyId(familyId);
        }

        [Route("StudentController/GetStudentsByAddressId")]
        [HttpGet]
        public List<Student> GetStudentsByAddressId(int adressId)
        {
            return StudentManager.GetStudentsByAddressId(adressId);
        }
      
    
        [Route("StudentController/GetStudentsWhoDontHavePsychologicalStatus")]
        [HttpGet]
        public List<Student> GetStudentsWhoDontHavePsychologicalStatus()
        {
            return StudentManager.GetStudentsWhoDontHavePsychologicalStatus();
        }
        [Route("StudentController/GetStudentsByPsychologicalStatusId")]
        [HttpGet]
        public List<Student> GetStudentsByPsychologicalStatusId(int psychologicalStatusId)
        {
            return StudentManager.GetStudentsByPsychologicalStatusId(psychologicalStatusId);
        }
        [Route("StudentController/GetSuccessfulStudentsByClassId")]
        [HttpGet]
        public List<Student> GetSuccessfulStudentsByClassId(int classId)
        {
            return StudentManager.GetSuccessfulStudentsByClassId(classId);
        }
        [Route("StudentController/GetFailingStudentsByClassId")]
        [HttpGet]
        public List<Student> GetFailingStudentsByClassId(int classId)
        {
            return StudentManager.GetFailingStudentsByClassId(classId);
        }
        [Route("StudentController/GetNewStudentsByClassId")]
        [HttpGet]
        public List<NewStudentSchoolYear> GetNewStudentsByClassId(int classId)
        {
            return StudentManager.GetNewStudentsByClassId(classId);
        }
        [Route("StudentController/UpdateIsActiveStudent")]
        [HttpPost]
        public int UpdateIsActiveStudent()
        {
            return StudentDataManager.UpdateIsActiveStudent();
        }
        [Route("StudentController/GetIsActiveStudent")]
        [HttpGet]
        public List<Student> GetIsActiveStudent()
        {
            return StudentManager.GetIsActiveStudent();
        }
        [Route("StudentController/GetActiveStudentsInCurrentSchoolYear")]
        [HttpGet]
        public List<Student> GetActiveStudentsInCurrentSchoolYear()
        {
            return StudentManager.GetIsActiveStudentsInCurrentSchoolYear();
        }
        [Route("StudentController/GetStudentInfo")]
        [HttpGet]
        public List<StudentInfo> GetStudentInfo()
        {
            return StudentInfoViewManager.GetStudentInfo();
        }
        [Route("StudentController/GetStudentInfoByStudentId")]
        [HttpGet]
        public List<StudentInfo> GetStudentInfoByStudentId(int studentId)
        {
            return StudentInfoViewManager.GetStudentInfoByStudentId(studentId);
        }


    }
}
