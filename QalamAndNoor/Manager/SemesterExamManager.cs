using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class SemesterExamManager
    {
        public static List<SemesterExam> GetSemesterExams()
        {
            return SemesterExamDataManager.GetSemesterExams().ToList();
        }
        public static int InsertSemesterExam(SemesterExam semesterExam)
        {
            return SemesterExamDataManager.InsertSemesterExam(semesterExam);
        }
        public static int UpdateSemesterExam(SemesterExam semesterExam)
        {
            return SemesterExamDataManager.UpdateSemesterExam(semesterExam);
        }
        public static int DeleteSemesterExam(SemesterExam semesterExam)
        {
            return SemesterExamDataManager.DeleteSemesterExam(semesterExam);
        }
        public static SemesterExam? GetSemesterExamById(int id)
        {
            List<SemesterExam> semesterExams = GetSemesterExams();
            foreach (SemesterExam semesterExam in semesterExams)
            {
                if (semesterExam.ID==id)
                {
                    return semesterExam;
                }
            }
            return null;
        }
        public static SemesterExam? GetSemesterExamByExamIdAndCourseIdAndSemesterYearRecordId(int examId,int semesterYearRecordId,int courseId)
        {
            List<SemesterExam> semesterExams = GetSemesterExams();
            foreach (SemesterExam item in semesterExams)
            {
                if (item.ExamId==examId&&item.CourseId==courseId&&item.SemesterYearecordId==semesterYearRecordId)
                {
                    return item;
                }
            }
            return null;
        }
     
    }
}
