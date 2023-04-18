using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class ExamManager
    {
        public static List<Exam> GetExams()
        {
            return ExamDataManager.GetExams().ToList();
        }
        public static int InsertExam(Exam exam) 
        {
            return ExamDataManager.InsertExam(exam);
        }
        public static int UpdateExam(Exam exam) {
        return ExamDataManager.UpdateExam(exam);
        }
        public static int DeleteExam(Exam exam)
        {
            return ExamDataManager.DeleteExam(exam);
        }
        public static Exam GetExamById(int id)
        {
            List<Exam> exams = GetExams();
            foreach (Exam exam in exams)
            {
                if (exam.ID==id)
                {
                    return exam;
                }
            }
            return null;
        }
    }
}
