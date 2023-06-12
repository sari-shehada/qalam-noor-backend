using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Manager.ViewsManager
{
    public abstract class StudentInfoViewManager
    {
        public static List<StudentInfo> GetStudentInfo()
        {
            return StudentInfoDataManager.GetStudentInfo();
        }
        public static List<StudentInfo> GetStudentInfoByStudentId(int studentId)
        {
            List<StudentInfo> studentInfo = GetStudentInfo();
            List<StudentInfo> result = new List<StudentInfo>();
            foreach (StudentInfo student in studentInfo)
            {
                if (student.StudentId==studentId)
                {
                    result.Add(student);
                }
            }
            return result;
        }
    }
}
