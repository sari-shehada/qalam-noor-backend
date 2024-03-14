using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.DataManager.ViewsDataManager;
using QalamAndNoor.Manager;
using QalamAndNoor.Manager.ViewsManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using QalamAndNoor.Models.HelperModels.DbHelper;

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
        public Student? GetStudentById(int id)
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
        [Route("StudentController/GetStudentsInCurrentSchoolYear")]
        [HttpGet]
        public List<Student> GetStudentsInCurrentSchoolYear()
        {
            return StudentManager.GetStudentsInCurrentSchoolYear();
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
        [Route("StudentController/GetStudentYearRecordsByStudentId")]
        [HttpGet]
        public List<StudentYearRecords> GetStudentYearRecordsByStudentId(int studentId)
        {
            return StudentYearRecordsManager.GetStudentYearRecordsByStudentId(studentId);
        }
        [Route("StudentController/RegistrationNewStudentInSchoolYear")]
        [HttpPost]
        public object RegistrationNewStudentInSchoolYear([FromBody] NewStudentRegistrationInSchoolYear newStudent)
        {
            return StudentManager.RegistrationNewStudentInSchoolYear(newStudent);
        }
        [Route("StudentController/RegistrationOldStudentInSchoolYear")]
        [HttpPost]
        public object RegistrationOldStudentInSchoolYear([FromBody] OldStudentRegistration oldStudent)
        {
            return StudentManager.RegistrationOldStudentInSchoolYear(oldStudent);
        }
        [Route("StudentController/GetActiveStudentsInSchoolYearByClassRoomId")]
        [HttpGet]
        public List<Student> GetActiceStudentsInSchoolYearByClassRoomId(int clasRoomId)
        {
            return StudentManager.GetActiceStudentsInSchoolYearByClassRoomId(clasRoomId);
        }
        [Route("StudentController/GetStudentExamMarks")]
        [HttpGet]
        public List<StudentExamMark> GetStudentExamMarks(int examId, int courseId, int clasRoomId)
        {
            return StudentManager.GetStudentExamMarks(courseId, examId, clasRoomId);
        }
        [Route("StudentController/InsertStudentsMark")]
        [HttpPost]
        public object InsertStudentsMark([FromBody] StudentExamMarkInsertion studentExamMarkInsertion)
        {
            return StudentManager.InsertStudentsMark(studentExamMarkInsertion);
        }
        [Route("StudentController/GetStudentReports")]
        [HttpGet]
        public List<StudentReport> GetStudentReports()
        {
            return StudentReportViewDataManager.GetStudentReports();
        }
        [Route("StudentController/GetStudentProfileByStudentId")]
        [HttpGet]
        public StudentProfileDto GetStudentProfileByStudentId(int studentId)
        {
            return StudentManager.GetStudentProfileByStudentId(studentId);
        }

        [Route("StudentController/GetFullStudentsInfo")]
        [HttpGet]
        public List<FullStudentInfo> GetFullStudentsInfo()
        {
            return StudentManager.GetStudentsInfo();
        }

        [Route("StudentController/GetStudentSemesterScoreScoresBySchoolYearIdAndSemesterIdAndStudentId")]
        [HttpGet]
        public object? GetStudentSemesterScoreScoresBySchoolYearIdAndSemesterIdAndStudentId
                    (int semesterId, int schoolYearId, int StudentId)
        {
            return StudentManager.GetStudentScoresBySchoolYearIdAndSemesterIdAndStudentId
            (semesterId, schoolYearId, StudentId);
        }

        [Route("StudentController/GetStudentSchoolYearScoreByStudentIdAndSchoolYearId")]
        [HttpGet]
        public StudentSchoolYearScore GetStudentSchoolYearScoreByStudentIdAndSchoolYearId(int schoolYearId,int studentId)
        {
            return StudentManager.GetStudentSchoolYearScoreByStudentIdAndSchoolYearId(studentId, schoolYearId);
        }
        [Route("StudentController/GetTotalStudentMarksByStudentIdAndSchoolYearId")]
        [HttpGet]
        public List<TotalStudentMark> GetTotalStudentMarksByStudentIdAndSchoolYearId(int schoolYearId,int studentId)
        {
            return TotalStudentMarkDataManager.GetTotalStudentMarksByStudentIdAndSchoolYearId(schoolYearId, studentId);
        }
        [Route("StudentController/GetFinalStudentScoreByStudentIdAndSchoolYearId")]
        [HttpGet]
        public FinalStudentScore GetFinalStudentScoreByStudentIdAndSchoolYearId(int studentId,int schoolyearId)
        {
            return FinalStudentScoreManager.GetFinalStudentScoreByStudentIdAndSchoolYearId(studentId,schoolyearId);
        }
        [Route("StudentController/RegistrationLateStudent")]
        [HttpPost]
        public object RegistrationLateStudent([FromBody]LateStudent lateStudent)
        {
            return StudentManager.RegistrationLateStudent(lateStudent);
        }
        [Route("StudentController/GetStudentCountBySchoolYearId")]
        [HttpGet]
        public int GetStudentCountBySchoolYearId(int schoolYearId)
        {
            return YearRecordManager.GetYearRecordsBySchoolYearId(schoolYearId).Count;
        }
        [Route("StudentController/GetPassStudentCountBySchoolYearId")]
        [HttpGet]
        public int GetPassStudentCountBySchoolYearId(int schoolYearId)
        {
            return YearRecordManager.GetPassYearRecordsBySchoolYearId(schoolYearId).Count;
        }
        [Route("StudentController/GetFailStudentCountBySchoolYearId")]
        [HttpGet]
        public int GetFailStudentCountBySchoolYearId(int schoolYearId)
        {
            return YearRecordManager.GetFailYearRecordsBySchoolYearId(schoolYearId).Count;
        }
        [Route("StudentController/GetStudentsBySchoolYearIdAndClassId")]
        [HttpGet]
        public List<StudentFatherYearRecord> GetStudentsBySchoolYearIdAndClassId(int schoolYearId,int classId)
        {
            return StudentManager.GetStudentsBySchoolYearIdAndClassId(schoolYearId,classId);
        }
        [Route("StudentController/GetStudentsBySchoolYearId")]
        [HttpGet]
        public List<StudentFatherYearRecord> GetStudentsBySchoolYearId(int schoolYearId)
        {
            return StudentManager.GetStudentsBySchoolYearId(schoolYearId);
        }


    }
}
