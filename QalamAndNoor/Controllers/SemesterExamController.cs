using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class SemesterExamController : ControllerBase
    {
        [Route("SemesterExamController/InsertSemesterExam")]
        [HttpPost]
        public int InsertSemesterExam(SemesterExam semesterExam)
        {
            return SemesterExamManager.InsertSemesterExam(semesterExam);
        }
        [Route("SemesterExamController/UpdateSemesterExam")]
        [HttpPost]
        public int UpdateSemesterExam(SemesterExam semesterExam)
        {
            return SemesterExamManager.UpdateSemesterExam(semesterExam);
        }
        [Route("SemesterExamController/DeleteSemesterExam")]
        [HttpPost]
        public int DeleteSemesterExam(SemesterExam semesterExam)
        {
            return SemesterExamManager.DeleteSemesterExam(semesterExam);
        }
        [Route("SemesterExamController/GetSemesterExams")]
        [HttpGet]
        public List< SemesterExam> GetSemesterExams()
        {
            return SemesterExamManager.GetSemesterExams();
        }
        [Route("SemesterExamController/GetSemesterExamById")]
        [HttpGet]
        public SemesterExam GetSemesterExamById(int id)
        {
            return SemesterExamManager.GetSemesterExamById(id);
        }
    }
}
