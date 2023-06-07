using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class ExamController : ControllerBase
    {
        [Route("ExamController/InsertExam")]
        [HttpPost]
        public int InsertExam([FromBody] Exam exam)
        {
            return ExamManager.InsertExam(exam);
        }
        [Route("ExamController/UpdateExam")]
        [HttpPost]
        public int UpdateExam([FromBody] Exam exam)
        {
            return ExamManager.UpdateExam(exam);
        }
        [Route("ExamController/DeleteExam")]
        [HttpPost]
        public int DeleteExam([FromBody] Exam exam)
        {
            return ExamManager.DeleteExam(exam);
        }
        [Route("ExamController/GetExams")]
        [HttpGet]
        public List<Exam> GetExams()
        {
            return ExamManager.GetExams();
        }
        [Route("ExamController/GetExamById")]
        [HttpGet]
        public Exam GetExamById(int id)
        {
            return ExamManager.GetExamById(id);
        }
        [Route("ExamController/GetExamsByClassId")]
        [HttpGet]
        public List<Exam> GetExamsByClassId(int classId)
        {
            return ExamManager.GetExamsByClassId(classId);
        }

    }
}
